namespace Profiles.Domain.Aggregates.Dto.Requests
{
  public class UpdateProfessionalDomainRequest
  {
    public required string ProfessionalId { get; init; }
    public string? Name { get; init; }
    public string? Email { get; init; }
    public bool? Disabled { get; init; }
  }
}
