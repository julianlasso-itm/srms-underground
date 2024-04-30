namespace Profiles.Domain.Aggregates.Dto.Requests
{
  public class UpdateRoleDomainRequest
  {
    public required string RoleId { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public bool? Disable { get; init; }
  }
}
