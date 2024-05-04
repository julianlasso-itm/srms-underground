using AccessControl.Application.Commands;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

namespace AccessControl.Infrastructure.AntiCorruption
{
  public class InfrastructureToApplication
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

    public GetRolesCommand MapToGetRolesCommand(GetRolesAccessControlRequest request)
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

    public RegisterRoleCommand MapToRegisterRoleCommand(
      RegisterRoleAccessControlRequest request
    )
    {
      return new RegisterRoleCommand { Name = request.Name, Description = request.Description };
    }

    public UpdateRoleCommand MapToUpdateRoleCommand(UpdateRoleAccessControlRequest request)
    {
      return new UpdateRoleCommand
      {
        RoleId = request.RoleId!,
        Name = request.Name,
        Description = request.Description,
        Disable = request.Disable
      };
    }

    public DeleteRoleCommand MapToDeleteRoleCommand(DeleteRoleAccessControlRequest request)
    {
      return new DeleteRoleCommand { RoleId = request.RoleId };
    }
  }
}
