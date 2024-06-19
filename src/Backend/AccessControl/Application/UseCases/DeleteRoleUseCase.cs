using System.Text.Json;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;
using Shared.Common.Bases;

namespace AccessControl.Application.UseCases
{
  public sealed class DeleteRoleUseCase<TEntity>(
    ISecurityAggregateRoot aggregateRoot,
    IRoleRepository<TEntity> roleRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      DeleteRoleCommand,
      DeleteRoleApplicationResponse,
      ISecurityAggregateRoot,
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
      var dataDeleteRole = AclInputMapper.ToDeleteRoleDomainRequest(request);
      var response = AggregateRoot.DeleteRole(dataDeleteRole);

      if (response.IsFailure)
      {
        return Response<DeleteRoleApplicationResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      var result = AclOutputMapper.ToDeleteRoleApplicationResponse(response.Data);
      _ = await Persistence(result);
      EmitEvent(Channel, JsonSerializer.Serialize(result));
      return Response<DeleteRoleApplicationResponse>.Success(result);
    }

    private async Task<TEntity> Persistence(DeleteRoleApplicationResponse response)
    {
      return await _roleRepository.DeleteAsync(Guid.Parse(response.RoleId));
    }
  }
}
