namespace Profiles.Domain.Aggregates.Dto.Responses
{
  public class UpdateRoleDomainResponse
  {
    public required string RoleId { get; init; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? Disabled { get; set; }
    public IEnumerable<string>? Skills { get; set; }
  }
}
