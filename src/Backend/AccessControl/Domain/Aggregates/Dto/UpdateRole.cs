namespace AccessControl.Domain.Aggregates.Dto;

public class UpdateRole
{
    public required string RoleId { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public bool? Disabled { get; init; }
}
