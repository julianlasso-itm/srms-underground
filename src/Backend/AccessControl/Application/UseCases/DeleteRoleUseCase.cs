using System.Net;
using System.Text.Json;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;
using Shared.Common.Bases;
using ApplicationException = Shared.Application.Exceptions.ApplicationException;

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
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, applicationToDomain, domainToApplication)
    where TEntity : class
  {
    private readonly IRoleRepository<TEntity> _roleRepository = roleRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventRoleDeleted}";

    public override async Task<Result> Handle(DeleteRoleCommand request)
    {
      var dataDeleteRole = AclInputMapper.ToDeleteRoleDomainRequest(request);
      var response = AggregateRoot.DeleteRole(dataDeleteRole);

      if (response.IsFailure)
      {
        return response;
      }

      if (response is SuccessResult<DeleteRoleDomainResponse> successResult)
      {
        var result = AclOutputMapper.ToDeleteRoleApplicationResponse(successResult.Data);
        _ = await Persistence(result);
        EmitEvent(Channel, JsonSerializer.Serialize(result));
        return new SuccessResult<DeleteRoleApplicationResponse>(result);
      }

      throw new ApplicationException(
        "Invalid response into DeleteRoleUseCase for AccessControl application",
        HttpStatusCode.InternalServerError
      );
    }

    private async Task<TEntity> Persistence(DeleteRoleApplicationResponse response)
    {
      return await _roleRepository.DeleteAsync(Guid.Parse(response.RoleId));
    }
  }
}
