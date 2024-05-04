using System.Text.Json;
using Profiles.Application.AntiCorruption.Interfaces;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Constants;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Profiles.Application.UseCases
{
  public sealed class RegisterRoleUseCase<TEntity>
    : BaseUseCase<
      RegisterRoleCommand,
      RegisterRoleApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TEntity : class
  {
    private readonly IRoleRepository<TEntity> _roleRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventRoleRegistered}";

    public RegisterRoleUseCase(
      IPersonnelAggregateRoot aggregateRoot,
      IRoleRepository<TEntity> roleRepository,
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication
    )
      : base(aggregateRoot, applicationToDomain, domainToApplication)
    {
      _roleRepository = roleRepository;
    }

    public override async Task<RegisterRoleApplicationResponse> Handle(RegisterRoleCommand request)
    {
      var newRole = MapToRequestForDomain(request);
      var role = AggregateRoot.RegisterRole(newRole);
      var response = MapToResponse(role);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
    }

    private RegisterRoleDomainRequest MapToRequestForDomain(RegisterRoleCommand request)
    {
      return new RegisterRoleDomainRequest
      {
        Name = request.Name,
        Description = request.Description,
      };
    }

    private RegisterRoleApplicationResponse MapToResponse(RegisterRoleDomainResponse role)
    {
      return new RegisterRoleApplicationResponse
      {
        RoleId = role.RoleId,
        Name = role.Name,
        Description = role.Description,
        Disabled = role.Disabled,
      };
    }

    private async Task<TEntity> Persistence(RegisterRoleApplicationResponse response)
    {
      return await _roleRepository.AddAsync(response);
    }
  }
}
