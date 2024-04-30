namespace Profiles.Domain.Aggregates.Dto.Requests
{
  public class RegisterProfessionalDomainRequest
  {
    public required string Name { get; init; }
    public required string Email { get; init; }
  }
}
