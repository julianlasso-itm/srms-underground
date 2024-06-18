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
using Shared.Common.Bases;

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
      request = AssignAvatarBlobAndDeleteFromCache(request);
      var command = AclInputMapper.ToRegisterCredentialDomainRequest(request);
      var user = AggregateRoot.RegisterCredential(command);
      user.Photo = await StoreAvatar(user.Avatar, user.AvatarExtension);
      var response = AclOutputMapper.ToRegisterUserApplicationResponse(user, request.CityId);
      _ = await Persist(response);
      SendConfirmationEmail(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
    }

    private RegisterUserCommand AssignAvatarBlobAndDeleteFromCache(RegisterUserCommand request)
    {
      request.AvatarBytes = GetAvatarBlob(request.Avatar);
      DeleteAvatarFromCache(request.Avatar);
      return request;
    }

    private async Task<TEntity> Persist(RegisterUserApplicationResponse response)
    {
      return await _userRepository.AddAsync(response);
    }

    private byte[] GetAvatarBlob(string avatar)
    {
      var avatarBlob =
        _cacheService.GetBytes(avatar) ?? throw new InvalidOperationException("Avatar not found.");
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
