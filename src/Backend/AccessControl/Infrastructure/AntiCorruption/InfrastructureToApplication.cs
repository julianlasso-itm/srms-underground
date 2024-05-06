using AccessControl.Application.Commands;
using AccessControl.Infrastructure.AntiCorruption.Interfaces;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

namespace AccessControl.Infrastructure.AntiCorruption
{
  public class InfrastructureToApplication : IInfrastructureToApplication
  {
    private static InfrastructureToApplication s_instance;

    public static InfrastructureToApplication Instance
    {
      get
      {
        s_instance ??= new InfrastructureToApplication();
        return s_instance;
      }
    }

    public GetRolesCommand ToGetRolesCommand(GetRolesAccessControlRequest request)
    {
      return new GetRolesCommand
      {
        Page = request.Page,
        Limit = request.Limit,
        Filter = request.Filter,
        FilterBy = request.FilterBy,
        Sort = request.Sort,
        Order = request.Order
      };
    }

    public RegisterRoleCommand ToRegisterRoleCommand(RegisterRoleAccessControlRequest request)
    {
      return new RegisterRoleCommand { Name = request.Name, Description = request.Description };
    }

    public UpdateRoleCommand ToUpdateRoleCommand(UpdateRoleAccessControlRequest request)
    {
      return new UpdateRoleCommand
      {
        RoleId = request.RoleId!,
        Name = request.Name,
        Description = request.Description,
        Disable = request.Disable
      };
    }

    public DeleteRoleCommand ToDeleteRoleCommand(DeleteRoleAccessControlRequest request)
    {
      return new DeleteRoleCommand { RoleId = request.RoleId };
    }
  }
}