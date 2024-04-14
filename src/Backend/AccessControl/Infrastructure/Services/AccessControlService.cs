using AccessControl.Application.Commands;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.AccessControl;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace AccessControl.Infrastructure.Services;

public class AccessControlService : IAccessControlServices
{
    private readonly ApplicationService _applicationService;

    public AccessControlService(ApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    public async Task<RegisterUserResponse> RegisterUserAsync(
        RegisterUserRequest request,
        CallContext context = default
    )
    {
        var app = _applicationService.GetApplication();

        var newUserCommand = new NewUserCommand
        {
            Email = request.Email,
            Password = request.Password,
            Roles = new List<string>()
        };

        var data = await app.RegisterUser(newUserCommand);
        var response = new RegisterUserResponse
        {
            UserId = data.UserId,
            Email = data.Email,
            Disabled = data.Disabled,
        };
        return response;
    }

    public async Task<RegisterRoleResponse> RegisterRoleAsync(
        RegisterRoleRequest request,
        CallContext context = default
    )
    {
        var app = _applicationService.GetApplication();

        var newRoleCommand = new NewRoleCommand
        {
            Name = request.Name,
            Description = request.Description
        };

        var data = await app.RegisterRole(newRoleCommand);
        var response = new RegisterRoleResponse
        {
            RoleId = data.RoleId,
            Name = data.Name,
            Description = data.Description,
            Disabled = data.Disabled,
        };
        return response;
    }

    public async Task<UpdateRoleResponse> UpdateRoleAsync(
        UpdateRoleRequest request,
        CallContext context = default
    )
    {
        var app = _applicationService.GetApplication();

        var updateRoleCommand = new UpdateRoleCommand
        {
            RoleId = request.RoleId,
            Name = request.Name,
            Description = request.Description,
            Disable = request.Disable
        };

        var data = await app.UpdateRole(updateRoleCommand);
        var response = new UpdateRoleResponse
        {
            RoleId = data.RoleId,
            Name = data.Name,
            Description = data.Description,
            Disabled = data.Disabled,
        };
        return response;
    }

    public async Task<DeleteRoleResponse> DeleteRoleAsync(
        DeleteRoleRequest request,
        CallContext context = default
    )
    {
        var app = _applicationService.GetApplication();

        var deleteRoleCommand = new DeleteRoleCommand { RoleId = request.RoleId };

        var data = await app.DeleteRole(deleteRoleCommand);
        var response = new DeleteRoleResponse { RoleId = data.RoleId, };
        return response;
    }

    public async Task<GetRolesResponse> GetRolesAsync(
        GetRolesRequest request,
        CallContext context = default
    )
    {
        var app = _applicationService.GetApplication();

        var getRolesCommand = new GetRolesCommand
        {
            Page = request.Page,
            Limit = request.Limit,
            Sort = request.Sort,
            Order = request.Order
        };

        var data = await app.GetRoles(getRolesCommand);
        var response = new GetRolesResponse
        {
            Roles = data
                .Roles.Select(role => new Role
                {
                    RoleId = role.RoleId.ToString(),
                    Name = role.Name,
                    Description = role.Description,
                    Disabled = role.Disabled
                })
                .ToList()
        };

        return response;
    }
}
