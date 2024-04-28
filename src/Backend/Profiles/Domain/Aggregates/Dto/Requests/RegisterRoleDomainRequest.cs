namespace Profiles.Domain.Aggregates.Dto.Requests
{
    public class RegisterRoleDomainRequest
    {
        public required string Name { get; init; }
        public string? Description { get; init; }
    }
}
