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

namespace AccessControl.Application.UseCases
{
  public sealed class RegisterRoleUseCase<TEntity>(
    ISecurityAggregateRoot aggregateRoot,
    IRoleRepository<TEntity> roleRepository,
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication
  )
    : BaseUseCase<
      RegisterRoleCommand,
      RegisterRoleApplicationResponse,
      ISecurityAggregateRoot,
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
      var newRole = AclInputMapper.ToRegisterRoleDomainRequest(request);
      var response = AggregateRoot.RegisterRole(newRole);

      if (response.IsFailure)
      {
        return Response<RegisterRoleApplicationResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      var data = response.Data;
      var result = MapToResponse(data);
      _ = await Persistence(result);
      EmitEvent(Channel, JsonSerializer.Serialize(result));
      return Response<RegisterRoleApplicationResponse>.Success(result);
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
