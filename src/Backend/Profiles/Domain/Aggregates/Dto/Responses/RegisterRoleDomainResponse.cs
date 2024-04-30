namespace Profiles.Domain.Aggregates.Dto.Responses
{
  public class RegisterRoleDomainResponse
  {
    public required string RoleId { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }
    public bool Disabled { get; init; }
  }
}
