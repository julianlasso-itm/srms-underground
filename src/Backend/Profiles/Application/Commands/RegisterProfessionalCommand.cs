namespace Profiles.Application.Commands
{
    public class RegisterProfessionalCommand
    {
        public string Name { get; init; }
        public string Email { get; set; }
        public bool Disabled { get; set; }
    }
}
