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

    public override async Task<DeleteRoleApplicationResponse> Handle(DeleteRoleCommand request)
    {
      var dataDeleteRole = AclInputMapper.ToDeleteRoleDomainRequest(request);
      var role = AggregateRoot.DeleteRole(dataDeleteRole);
      var response = AclOutputMapper.ToDeleteRoleApplicationResponse(role);
      _ = await Persistence(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      return response;
    }

    private async Task<TEntity> Persistence(DeleteRoleApplicationResponse response)
    {
      return await _roleRepository.DeleteAsync(Guid.Parse(response.RoleId));
    }
  }
}
