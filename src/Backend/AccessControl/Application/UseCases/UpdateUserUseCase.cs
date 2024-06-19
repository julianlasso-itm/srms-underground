using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Application.Interfaces;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Common.Enums;

namespace AccessControl.Application.UseCases
{
  public sealed class UpdateUserUseCase<TEntity>(
    IUserRepository<TEntity> roleRepository,
    ICacheService cachingService,
    IStoreService storeService,
    ISecurityAggregateRoot aggregateRoot,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      UpdateUserCommand,
      UpdateUserApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private const string ContainerName = "users";
    private readonly IUserRepository<TEntity> _roleRepository = roleRepository;
    private readonly ICacheService _cacheService = cachingService;
    private readonly IStoreService _storeService = storeService;

    public override async Task<Result<UpdateUserApplicationResponse>> Handle(
      UpdateUserCommand request
    )
    {
      if (request.Avatar is not null && request.AvatarExtension is not null)
      {
        var requestFromCache = AssignAvatarBlobAndDeleteFromCache(request);
        if (requestFromCache.IsFailure)
        {
          return Response<UpdateUserApplicationResponse>.Failure(
            requestFromCache.Message,
            requestFromCache.Code,
            requestFromCache.Details
          );
        }

        request = requestFromCache.Data;
      }

      var dataUpdateUser = AclInputMapper.ToUpdateUserDomainRequest(request);
      var response = AggregateRoot.UpdateCredential(dataUpdateUser);
      if (response.IsFailure)
      {
        return Response<UpdateUserApplicationResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      var user = response.Data;
      if (request.Avatar is not null && request.AvatarExtension is not null)
      {
        user.Photo = await StoreAvatar(user.Avatar!, user.AvatarExtension!);
        await RemoveOldPhoto(request.OldPhoto!);
      }
      var result = AclOutputMapper.ToUpdateUserApplicationResponse(user);
      _ = await Persistence(result);
      return new SuccessResult<UpdateUserApplicationResponse>(result);
    }

    private Result<UpdateUserCommand> AssignAvatarBlobAndDeleteFromCache(UpdateUserCommand request)
    {
      request.AvatarBytes = GetAvatarBlob(request.Avatar!);
      if (request.AvatarBytes.Length == 0)
      {
        return Response<UpdateUserCommand>.Failure("Avatar not found", ErrorEnum.NOT_FOUND);
      }
      DeleteAvatarFromCache(request.Avatar!);
      return Response<UpdateUserCommand>.Success(request);
    }

    private byte[] GetAvatarBlob(string avatar)
    {
      return _cacheService.GetBytes(avatar) ?? [];
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
