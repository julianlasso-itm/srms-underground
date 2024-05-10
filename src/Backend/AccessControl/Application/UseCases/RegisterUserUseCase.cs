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

namespace AccessControl.Application.UseCases
{
  public sealed class RegisterUserUseCase<TEntity>
    : BaseUseCase<
      RegisterUserCommand,
      RegisterUserApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TEntity : class
  {
    private const string ContainerName = "users";
    private readonly IUserRepository<TEntity> _userRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCredentialRegistered}";
    private readonly ICacheService _cacheService;
    private readonly IStoreService _storeService;
    private readonly IMessageService _messageService;

    public RegisterUserUseCase(
      ISecurityAggregateRoot aggregateRoot,
      IUserRepository<TEntity> userRepository,
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication,
      IMessageService messageService,
      ICacheService cacheService,
      IStoreService storeService
    )
      : base(aggregateRoot, applicationToDomain, domainToApplication)
    {
      _userRepository = userRepository;
      _cacheService = cacheService;
      _storeService = storeService;
      _messageService = messageService;
    }

    public override async Task<RegisterUserApplicationResponse> Handle(RegisterUserCommand request)
    {
      request.AvatarBytes = GetAvatarBlob(request.Avatar);
      DeleteAvatarFromCache(request.Avatar);
      var command = AclInputMapper.ToRegisterCredentialDomainRequest(request);
      var user = AggregateRoot.RegisterCredential(command);
      if (user.Photo.Length == 0)
      {
        user.Photo = await StoreAvatar(user.Avatar, user.AvatarExtension);
      }
      var response = AclOutputMapper.ToRegisterUserApplicationResponse(user);

      _ = await Persist(response);
      SendConfirmationEmail(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return response;
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
      _cacheService.Set($"Token-{token}", response.UserId, TimeSpan.FromHours(24));
      _messageService.SendConfirmationEmail(response.Name, response.Email, token);
    }
  }
}
