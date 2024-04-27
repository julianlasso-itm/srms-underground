namespace Profiles.Domain.Aggregates.Dto.Requests;
{
    [DataContract]
    public class UpdateRoleDomainRequest
    {
        [DataMember(Order = 1)]
        public required string RoleId { get; init; }

        [DataMember(Order = 2)]
        public string? Name { get; init; }

        [DataMember(Order = 3)]
        public string? Description { get; init; }

        [DataMember(Order = 4)]
        public bool? Disable { get; init; }
    }
}
