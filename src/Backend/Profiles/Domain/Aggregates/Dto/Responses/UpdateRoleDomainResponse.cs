namespace Profiles.Domain.Aggregates.Dto.Responses;
{
    [DataContract]
    public class UpdateRoleDomainResponse
    {
        [DataMember(Order = 1)]
        public required string RoleId { get; init; }

        [DataMember(Order = 2)]
        public string? Name { get; set; }

        [DataMember(Order = 3)]
        public string? Description { get; set; }

        [DataMember(Order = 4)]
        public bool? Disabled { get; set; }
    }
}
