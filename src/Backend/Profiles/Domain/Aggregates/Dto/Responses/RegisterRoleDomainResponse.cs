namespace Profiles.Domain.Aggregates.Dto.Responses;

{
   [DataContract]
    public class RegisterRoleDomainResponse
    {
        [DataMember(Order = 1)]
        public required string RoleId { get; init; }

        [DataMember(Order = 2)]
        public required string Name { get; init; }

        [DataMember(Order = 3)]
        public string? Description { get; init; }

        [DataMember(Order = 4)]
        public required bool Disabled { get; init; }
    }
}
