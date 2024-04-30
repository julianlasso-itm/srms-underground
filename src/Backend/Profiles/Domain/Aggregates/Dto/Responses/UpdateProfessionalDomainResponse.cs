namespace Profiles.Domain.Aggregates.Dto.Requests
{
  public class UpdateProfessionalDomainResponse
  {
    public required string ProfessionalId { get; init; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool Disabled { get; set; }
  }
}
