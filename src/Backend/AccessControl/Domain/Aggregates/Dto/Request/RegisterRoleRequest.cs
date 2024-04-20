namespace AccessControl.Domain.Aggregates.Dto;

public class RegisterRoleRequest
{
    public required string Name { get; init; }
    public string? Description { get; init; }
}
