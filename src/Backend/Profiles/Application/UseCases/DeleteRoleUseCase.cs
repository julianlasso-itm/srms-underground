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
using Shared.Common;

namespace Profiles.Application.UseCases
{
  public sealed class DeleteRoleUseCase<TEntity>(
    IPersonnelAggregateRoot aggregateRoot,
    IRoleRepository<TEntity> roleRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      DeleteRoleCommand,
      DeleteRoleApplicationResponse,
      IPersonnelAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly IRoleRepository<TEntity> _roleRepository = roleRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventRoleDeleted}";

    public override async Task<Result<DeleteRoleApplicationResponse>> Handle(
      DeleteRoleCommand request
    )
    {
      var dataDeleteRole = MapToRequestForDomain(request);
      var role = AggregateRoot.DeleteRole(dataDeleteRole);

      if (role.IsFailure)
      {
        return Response<DeleteRoleApplicationResponse>.Failure(
          role.Message,
          role.Code,
          role.Details
        );
      }
      var response = MapToResponse(role.Data);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));

      return Response<DeleteRoleApplicationResponse>.Success(response);
    }

    private DeleteRoleDomainRequest MapToRequestForDomain(DeleteRoleCommand request)
    {
      return new DeleteRoleDomainRequest { RoleId = request.RoleId };
    }

    private DeleteRoleApplicationResponse MapToResponse(DeleteRoleDomainResponse role)
    {
      return new DeleteRoleApplicationResponse { RoleId = role.RoleId };
    }

    private async Task<TEntity> Persistence(DeleteRoleApplicationResponse response)
    {
      return await _roleRepository.DeleteAsync(Guid.Parse(response.RoleId));
    }
  }
}
