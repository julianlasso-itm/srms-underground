using System.Text.Json;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;

namespace AccessControl.Application.UseCases
{
  public sealed class UpdateRoleUseCase<TEntity>(
    ISecurityAggregateRoot aggregateRoot,
    IRoleRepository<TEntity> roleRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      UpdateRoleCommand,
      UpdateRoleApplicationResponse,
      ISecurityAggregateRoot,
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
      var dataUpdateRole = AclInputMapper.ToUpdateRoleDomainRequest(request);
      var response = AggregateRoot.UpdateRole(dataUpdateRole);
      if (response.IsFailure)
      {
        return Response<UpdateRoleApplicationResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      var data = response.Data;
      var result = AclOutputMapper.ToUpdateRoleApplicationResponse(data);
      _ = await Persistence(result);
      EmitEvent(Channel, JsonSerializer.Serialize(result));
      return Response<UpdateRoleApplicationResponse>.Success(result);
    }

    private async Task<TEntity> Persistence(UpdateRoleApplicationResponse response)
    {
      return await _roleRepository.UpdateAsync(Guid.Parse(response.RoleId), response);
    }
  }
}
