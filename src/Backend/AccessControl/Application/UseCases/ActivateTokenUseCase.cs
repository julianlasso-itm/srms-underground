using System.Text.Json;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Application.Interfaces;

namespace AccessControl.Application.UseCases
{
  public sealed class ActivateTokenUseCase<TEntity>
    : BaseUseCase<
      ActivateTokenCommand,
      ActivationTokenApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TEntity : class
  {
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCredentialActivated}";
    private readonly IUserRepository<TEntity> _userRepository;
    private readonly ICacheService _cacheService;

    public ActivateTokenUseCase(
      IUserRepository<TEntity> userRepository,
      ICacheService cacheService,
      ISecurityAggregateRoot aggregateRoot,
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication
    )
      : base(aggregateRoot, applicationToDomain, domainToApplication)
    {
      _userRepository = userRepository;
      _cacheService = cacheService;
    }

    public override async Task<ActivationTokenApplicationResponse> Handle(
      ActivateTokenCommand request
    )
    {
      var command = AclInputMapper.ToActivateTokenDomainRequest(request);
      var response = AggregateRoot.ValidateActivationToken(command);
      var userId = GetUserIdFromCache(response.ActivationToken);
      var requestForDomain = AclInputMapper.ToActiveCredentialDomainRequest(
        new ActiveUserCommand { UserId = userId }
      );
      var user = AggregateRoot.ActiveCredential(requestForDomain);
      await ChangeUserStatusInDatabase(userId);
      RemoveTokenFromCache(response.ActivationToken);
      EmitEvent(Channel, JsonSerializer.Serialize(user));
      return AclOutputMapper.ToActivationTokenApplicationResponse(response);
    }

    private string GetUserIdFromCache(string token)
    {
      return _cacheService.Get($"token:{token}")
        ?? throw new ApplicationException("User activation token not found.");
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
