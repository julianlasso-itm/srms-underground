using System.Net;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
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

    public override async Task<Result> Handle(UpdateUserCommand request)
    {
      if (request.Avatar is not null && request.AvatarExtension is not null)
      {
        var requestFromCache = AssignAvatarBlobAndDeleteFromCache(request);
        if (requestFromCache.IsFailure)
        {
          return requestFromCache;
        }

        if (requestFromCache is SuccessResult<UpdateUserCommand> successRequest)
        {
          request = successRequest.Data;
        }
      }

      var dataUpdateUser = AclInputMapper.ToUpdateUserDomainRequest(request);
      var response = AggregateRoot.UpdateCredential(dataUpdateUser);
      if (response.IsFailure)
      {
        return response;
      }

      if (response is SuccessResult<UpdateCredentialDomainResponse> successResponse)
      {
        var user = successResponse.Data;
        if (request.Avatar is not null && request.AvatarExtension is not null)
        {
          user.Photo = await StoreAvatar(user.Avatar!, user.AvatarExtension!);
          await RemoveOldPhoto(request.OldPhoto!);
        }
        var result = AclOutputMapper.ToUpdateUserApplicationResponse(user);
        _ = await Persistence(result);
        return new SuccessResult<UpdateUserApplicationResponse>(result);
      }

      throw new ApplicationException(
        "Invalid response into UpdateUserUseCase for AccessControl application",
        HttpStatusCode.InternalServerError
      );
    }

    private Result AssignAvatarBlobAndDeleteFromCache(UpdateUserCommand request)
    {
      request.AvatarBytes = GetAvatarBlob(request.Avatar!);
      if (request.AvatarBytes.Length == 0)
      {
        return new ErrorResult("Avatar not found", ErrorEnum.NOT_FOUND);
      }
      DeleteAvatarFromCache(request.Avatar!);
      return new SuccessResult<UpdateUserCommand>(request);
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
