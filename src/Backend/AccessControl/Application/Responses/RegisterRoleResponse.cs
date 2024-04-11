namespace AccessControl.Application.Responses;

public sealed class RegisterRoleResponse
{
    public required string RoleId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required bool Disabled { get; init; }
}
