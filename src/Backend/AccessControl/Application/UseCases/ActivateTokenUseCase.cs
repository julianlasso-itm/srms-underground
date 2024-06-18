using System.Net;
using System.Text.Json;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
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
  public sealed class ActivateTokenUseCase<TEntity>(
    IUserRepository<TEntity> userRepository,
    ICacheService cacheService,
    ISecurityAggregateRoot aggregateRoot,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      ActivateTokenCommand,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCredentialActivated}";
    private readonly IUserRepository<TEntity> _userRepository = userRepository;
    private readonly ICacheService _cacheService = cacheService;

    public override async Task<Result> Handle(ActivateTokenCommand request)
    {
      var command = AclInputMapper.ToActivateTokenDomainRequest(request);
      var response = AggregateRoot.ValidateActivationToken(command);

      if (response.IsFailure)
      {
        return response;
      }

      if (response is SuccessResult<ActivateTokenDomainResponse> successResult)
      {
        var data = successResult.Data;
        var userId = GetUserIdFromCache(data.ActivationToken);
        if (string.IsNullOrEmpty(userId))
        {
          return new ErrorResult("Token not found in cache", ErrorEnum.NOT_FOUND);
        }
        var requestForDomain = AclInputMapper.ToActiveCredentialDomainRequest(
          new ActiveUserCommand { UserId = userId }
        );
        var user = AggregateRoot.ActiveCredential(requestForDomain);
        await ChangeUserStatusInDatabase(userId);
        RemoveTokenFromCache(data.ActivationToken);
        EmitEvent(Channel, JsonSerializer.Serialize(user));

        return new SuccessResult<ActivationTokenApplicationResponse>(
          AclOutputMapper.ToActivationTokenApplicationResponse(data)
        );
      }

      throw new ApplicationException(
        "Invalid response into ActivateTokenUseCase for AccessControl application",
        HttpStatusCode.InternalServerError
      );
    }

    private string GetUserIdFromCache(string token)
    {
      return _cacheService.Get($"token:{token}") ?? string.Empty;
    }

    private async Task ChangeUserStatusInDatabase(string userId)
    {
      var data = new UpdateUserApplicationResponse { UserId = userId, Disabled = false };
      await _userRepository.UpdateAsync(Guid.Parse(userId), data);
    }

    private void RemoveTokenFromCache(string token)
    {
      _cacheService.Remove($"token:{token}");
    }
  }
}
