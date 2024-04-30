namespace AccessControl.Application.Responses
{
  public sealed class UpdateRoleApplicationResponse
  {
    public required string RoleId { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public bool? Disabled { get; init; }
  }
}
