using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Dto;
using AccessControl.Application.Interfaces;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Application.Interfaces;

namespace AccessControl.Application.UseCases
{
  public sealed class PasswordRecoveryUseCase<TEntity>(
    IUserRepository<TEntity> userRepository,
    ICacheService cacheService,
    IMessageService messageService,
    ISecurityAggregateRoot aggregateRoot,
    IApplicationToDomain aclInputMapper,
    IDomainToApplication aclOutputMapper
  )
    : BaseUseCase<
      PasswordRecoveryCommand,
      PasswordRecoveryApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, aclInputMapper, aclOutputMapper)
    where TEntity : class
  {
    private const int MaxTokenMinutes = 30;
    private readonly IUserRepository<TEntity> _userRepository = userRepository;
    private readonly ICacheService _cacheService = cacheService;
    private readonly IMessageService _messageService = messageService;

    public override async Task<PasswordRecoveryApplicationResponse> Handle(
      PasswordRecoveryCommand request
    )
    {
      try
      {
        var command = AclInputMapper.ToPasswordRecoveryDomainRequest(request);
        var response = AggregateRoot.PasswordRecovery(command);

        var user = await VerifyEmail(response.Email);
        var token = Guid.NewGuid().ToString().Replace("-", string.Empty);

        _messageService.SendPasswordRecoveryEmail(user.Name, response.Email, token);
        _cacheService.Set(
          $"recovery:{token}",
          response.Email,
          TimeSpan.FromMinutes(MaxTokenMinutes)
        );

        return AclOutputMapper.ToPasswordRecoveryApplicationResponse();
      }
      catch (Exception exception)
      {
        if (exception.Message == "Data not found")
        {
          return AclOutputMapper.ToPasswordRecoveryApplicationResponse();
        }
        throw;
      }
    }

    private async Task<UserDataForRecoveryPasswordDto> VerifyEmail(string email)
    {
      return await _userRepository.GetByEmail(email);
    }
  }
}
