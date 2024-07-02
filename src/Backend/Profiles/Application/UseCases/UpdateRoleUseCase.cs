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

namespace Profiles.Application.UseCases
{
  public sealed class UpdateRoleUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    IRoleRepository<TEntity> roleRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      UpdateRoleCommand,
      UpdateRoleApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly IRoleRepository<TEntity> _roleRepository = roleRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventRoleUpdated}";

    public override async Task<Result<UpdateRoleApplicationResponse>> Handle(
      UpdateRoleCommand request
    )
    {
      var dataUpdateRole = MapToRequestForDomain(request);
      var role = AggregateRoot.UpdateRole(dataUpdateRole);

      if (role.IsFailure)
      {
        return Response<UpdateRoleApplicationResponse>.Failure(
          role.Message,
          role.Code,
          role.Details
        );
      }
      var response = MapToResponse(role.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<UpdateRoleApplicationResponse>.Success(response);
    }

    private UpdateRoleDomainRequest MapToRequestForDomain(UpdateRoleCommand request)
    {
      return new UpdateRoleDomainRequest
      {
        RoleId = request.RoleId,
        Name = request.Name,
        Description = request.Description,
        Disable = request.Disable,
        Skills = request.Skills,
      };
    }

    private UpdateRoleApplicationResponse MapToResponse(UpdateRoleDomainResponse role)
    {
      return new UpdateRoleApplicationResponse
      {
        RoleId = role.RoleId,
        Name = role.Name,
        Description = role.Description,
        Disabled = role.Disabled,
        Skills = role.Skills,
      };
    }

    private async Task<TEntity> Persistence(UpdateRoleApplicationResponse response)
    {
      return await _roleRepository.UpdateAsync(Guid.Parse(response.RoleId), response);
    }
  }
}
