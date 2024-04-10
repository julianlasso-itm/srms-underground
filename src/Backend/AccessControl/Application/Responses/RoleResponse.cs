namespace AccessControl.Application.Responses;

public sealed class RoleResponse
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required bool Disabled { get; init; }
}
