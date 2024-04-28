namespace Profiles.Domain.Aggregates.Dto.Requests
{
    public class UpdateProfessionalDomainRequest
    {
        public required string ProfessionalId { get; set; }
        public string? Name { get; set; }
        public bool? Disabled { get; set; }
        public required string Email { get; set; }
    }
}
