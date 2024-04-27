namespace Profiles.Application.Commands
{
    public class UpdateProfessionalCommand
    {
        public required string ProfessionalId { get; set; }
        public string Email { get; set; }
        public string? Name { get; set; }
        public bool? Disabled { get; set; }
    }
}
