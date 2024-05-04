using System.Text.Json;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

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
    private readonly IUserRepository<TEntity> _userRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCredentialRegistered}";

    public RegisterUserUseCase(
      ISecurityAggregateRoot aggregateRoot,
      IUserRepository<TEntity> userRepository,
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication
    )
      : base(aggregateRoot, applicationToDomain, domainToApplication)
    {
      _userRepository = userRepository;
    }

    public override async Task<RegisterUserApplicationResponse> Handle(RegisterUserCommand request)
    {
      var command = AclInputMapper.ToRegisterCredentialDomainRequest(request);
      var user = AggregateRoot.RegisterCredential(command);
      var response = AclOutputMapper.ToRegisterUserApplicationResponse(user);
      _ = await Persist(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
    }

    private async Task<TEntity> Persist(RegisterUserApplicationResponse response)
    {
      return await _userRepository.AddAsync(response);
    }
  }
}
