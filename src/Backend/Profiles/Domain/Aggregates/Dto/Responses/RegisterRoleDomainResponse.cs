namespace Profiles.Domain.Aggregates.Dto.Responses
{
    public class RegisterRoleDomainResponse
    {
        public required string RoleId { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public required bool Disabled { get; init; }
    }
}
