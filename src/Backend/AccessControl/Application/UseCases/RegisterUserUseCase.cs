using System.Net;
using System.Text.Json;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Interfaces;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Application.Interfaces;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Common.Enums;
using ApplicationException = Shared.Application.Exceptions.ApplicationException;

namespace AccessControl.Application.UseCases
{
  public sealed class RegisterUserUseCase<TEntity>(
    ISecurityAggregateRoot aggregateRoot,
    IUserRepository<TEntity> userRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication,
    IMessageService messageService,
    ICacheService cacheService,
    IStoreService storeService
  )
    : BaseUseCase<
      RegisterUserCommand,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private const string ContainerName = "users";
    private readonly IUserRepository<TEntity> _userRepository = userRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCredentialRegistered}";
    private readonly ICacheService _cacheService = cacheService;
    private readonly IStoreService _storeService = storeService;
    private readonly IMessageService _messageService = messageService;

    public override async Task<Result> Handle(RegisterUserCommand request)
    {
      var newRequest = AssignAvatarBlobAndDeleteFromCache(request);

      if (newRequest.IsFailure)
      {
        return newRequest;
      }

      if (newRequest is SuccessResult<RegisterUserCommand> successRequest)
      {
        request = successRequest.Data;
      }

      var command = AclInputMapper.ToRegisterCredentialDomainRequest(request);
      var response = AggregateRoot.RegisterCredential(command);

      if (response.IsFailure)
      {
        return response;
      }

      if (response is SuccessResult<RegisterCredentialDomainResponse> successResult)
      {
        var data = successResult.Data;
        data.Photo = await StoreAvatar(data.Avatar, data.AvatarExtension);
        var result = AclOutputMapper.ToRegisterUserApplicationResponse(data, request.CityId);
        _ = await Persist(result);
        SendConfirmationEmail(result);
        EmitEvent(Channel, JsonSerializer.Serialize(result));
        return new SuccessResult<RegisterUserApplicationResponse>(result);
      }

      throw new ApplicationException(
        "Invalid response into RegisterUserUseCase for AccessControl application",
        HttpStatusCode.InternalServerError
      );
    }

    private Result AssignAvatarBlobAndDeleteFromCache(RegisterUserCommand request)
    {
      request.AvatarBytes = GetAvatarBlob(request.Avatar);
      if (request.AvatarBytes.Length == 0)
      {
        return new ErrorResult("Avatar not found.", ErrorEnum.NOT_FOUND);
      }
      DeleteAvatarFromCache(request.Avatar);
      return new SuccessResult<RegisterUserCommand>(request);
    }

    private async Task<TEntity> Persist(RegisterUserApplicationResponse response)
    {
      return await _userRepository.AddAsync(response);
    }

    private byte[] GetAvatarBlob(string avatar)
    {
      var avatarBlob = _cacheService.GetBytes(avatar) ?? [];
      return avatarBlob;
    }

    private async Task<string> StoreAvatar(byte[] avatarBlob, string extension)
    {
      return await _storeService.AddAsync(avatarBlob, extension, ContainerName);
    }

    private void DeleteAvatarFromCache(string avatar)
    {
      _cacheService.Remove(avatar);
    }

    private void SendConfirmationEmail(RegisterUserApplicationResponse response)
    {
      var token = Guid.NewGuid().ToString().Replace("-", string.Empty);
      _cacheService.Set($"token:{token}", response.UserId, TimeSpan.FromHours(24));
      _messageService.SendConfirmationEmail(response.Name, response.Email, token);
    }
  }
}
