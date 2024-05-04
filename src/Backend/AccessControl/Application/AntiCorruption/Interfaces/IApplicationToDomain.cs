using AccessControl.Application.Commands;
using AccessControl.Domain.Aggregates.Dto.Requests;

namespace AccessControl.Application.AntiCorruption.Interfaces
{
  public interface IApplicationToDomain
  {
    public RegisterRoleDomainRequest ToRegisterRoleDomainRequest(RegisterRoleCommand request);
    public UpdateRoleDomainRequest ToUpdateRoleDomainRequest(UpdateRoleCommand request);
    public DeleteRoleDomainRequest ToDeleteRoleDomainRequest(DeleteRoleCommand request);
  }
}
