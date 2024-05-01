namespace Profiles.Application.Commands
{
  public class UpdateProfessionalCommand
  {
    public required string ProfessionalId { get; init; }
    public string Email { get; init; }
    public string? Name { get; init; }
    public bool? Disable { get; init; }
  }
}
