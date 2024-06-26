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
using Shared.Common;
using Shared.Common.Bases;

namespace Profiles.Application.UseCases
{
  public sealed class RegisterRoleUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    IRoleRepository<TEntity> roleRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      RegisterRoleCommand,
      RegisterRoleApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly IRoleRepository<TEntity> _roleRepository = roleRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventRoleRegistered}";

    public override async Task<Result<RegisterRoleApplicationResponse>> Handle(
      RegisterRoleCommand request
    )
    {
      var newRole = MapToRequestForDomain(request);
      var role = AggregateRoot.RegisterRole(newRole);

      if (role.IsFailure)
      {
        return Response<RegisterRoleApplicationResponse>.Failure(
          role.Message,
          role.Code,
          role.Details
        );
      }
      var response = MapToResponse(role.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<RegisterRoleApplicationResponse>.Success(response);
    }

    private RegisterRoleDomainRequest MapToRequestForDomain(RegisterRoleCommand request)
    {
      return new RegisterRoleDomainRequest
      {
        Name = request.Name,
        Description = request.Description,
        Skills = request.Skills,
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
        Skills = role.Skills,
      };
    }

    private async Task<TEntity> Persistence(RegisterRoleApplicationResponse response)
    {
      return await _roleRepository.AddAsync(response);
    }
  }
}
