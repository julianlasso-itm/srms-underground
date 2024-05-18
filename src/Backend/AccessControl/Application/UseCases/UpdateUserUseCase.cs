using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Application.Interfaces;

namespace Application.UseCases
{
  public sealed class UpdateUserUseCase<TEntity>
    : BaseUseCase<
      UpdateUserCommand,
      UpdateUserApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TEntity : class
  {
    private const string ContainerName = "users";
    private readonly IUserRepository<TEntity> _roleRepository;
    private readonly ICacheService _cacheService;
    private readonly IStoreService _storeService;

    public UpdateUserUseCase(
      IUserRepository<TEntity> roleRepository,
      ICacheService cachingService,
      IStoreService storeService,
      ISecurityAggregateRoot aggregateRoot,
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication
    )
      : base(aggregateRoot, applicationToDomain, domainToApplication)
    {
      _roleRepository = roleRepository;
      _cacheService = cachingService;
      _storeService = storeService;
    }

    public override async Task<UpdateUserApplicationResponse> Handle(UpdateUserCommand request)
    {
      if (request.Avatar is not null && request.AvatarExtension is not null)
      {
        request = AssignAvatarBlobAndDeleteFromCache(request);
      }
      var dataUpdateUser = AclInputMapper.ToUpdateUserDomainRequest(request);
      var user = AggregateRoot.UpdateCredential(dataUpdateUser);
      if (request.Avatar is not null && request.AvatarExtension is not null)
      {
        user.Photo = await StoreAvatar(user.Avatar!, user.AvatarExtension!);
        await RemoveOldPhoto(request.OldPhoto!);
      }
      var response = AclOutputMapper.ToUpdateUserApplicationResponse(user);
      _ = await Persistence(response);
      return response;
    }

    private UpdateUserCommand AssignAvatarBlobAndDeleteFromCache(UpdateUserCommand request)
    {
      request.AvatarBytes = GetAvatarBlob(request.Avatar!);
      DeleteAvatarFromCache(request.Avatar!);
      return request;
    }

    private byte[] GetAvatarBlob(string avatar)
    {
      var avatarBlob =
        _cacheService.GetBytes(avatar) ?? throw new InvalidOperationException("Avatar not found.");
      return avatarBlob;
    }

    private void DeleteAvatarFromCache(string avatar)
    {
      _cacheService.Remove(avatar);
    }

    private async Task<string> StoreAvatar(byte[] avatarBlob, string extension)
    {
      return await _storeService.AddAsync(avatarBlob, extension, ContainerName);
    }

    private async Task RemoveOldPhoto(string photo)
    {
      await _storeService.RemoveAsync(photo, ContainerName);
    }

    private async Task<TEntity> Persistence(UpdateUserApplicationResponse response)
    {
      return await _roleRepository.UpdateAsync(Guid.Parse(response.UserId), response);
    }
  }
}
