namespace AccessControl.Domain.Aggregates.Dto;

public class UpdateRoleResponse
{
    public required string RoleId { get; init; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? Disabled { get; set; }
}
