using System.Text.Json;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Interfaces;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Application.Interfaces;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Common.Enums;

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
      RegisterUserApplicationResponse,
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

    public override async Task<Result<RegisterUserApplicationResponse>> Handle(
      RegisterUserCommand request
    )
    {
      var newRequest = AssignAvatarBlobAndDeleteFromCache(request);

      if (newRequest.IsFailure)
      {
        return Response<RegisterUserApplicationResponse>.Failure(
          newRequest.Message,
          newRequest.Code,
          newRequest.Details
        );
      }

      request = newRequest.Data;
      var command = AclInputMapper.ToRegisterCredentialDomainRequest(request);
      var response = AggregateRoot.RegisterCredential(command);

      if (response.IsFailure)
      {
        return Response<RegisterUserApplicationResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      var data = response.Data;
      data.Photo = await StoreAvatar(data.Avatar, data.AvatarExtension);
      var result = AclOutputMapper.ToRegisterUserApplicationResponse(data, request.CityId);
      _ = await Persist(result);
      SendConfirmationEmail(result);
      EmitEvent(Channel, JsonSerializer.Serialize(result));

      return Response<RegisterUserApplicationResponse>.Success(result);
    }

    private Result<RegisterUserCommand> AssignAvatarBlobAndDeleteFromCache(
      RegisterUserCommand request
    )
    {
      request.AvatarBytes = GetAvatarBlob(request.Avatar);
      if (request.AvatarBytes.Length == 0)
      {
        return Response<RegisterUserCommand>.Failure("Avatar not found.", ErrorEnum.NOT_FOUND);
      }
      DeleteAvatarFromCache(request.Avatar);
      return Response<RegisterUserCommand>.Success(request);
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
