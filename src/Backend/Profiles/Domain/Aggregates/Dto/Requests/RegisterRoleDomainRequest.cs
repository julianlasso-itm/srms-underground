namespace Profiles.Domain.Aggregates.Dto.Requests;
{
    [DataContract]
    public class RegisterRoleDomainRequest
    {
        [DataMember(Order = 1)]
        public required string Name { get; init; }
        public string? Description { get; init; }
    }
}
