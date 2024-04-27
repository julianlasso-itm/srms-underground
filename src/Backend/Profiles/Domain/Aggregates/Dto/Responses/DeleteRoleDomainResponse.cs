namespace Profiles.Domain.Aggregates.Dto.Responses;
{
    [DataContract]
    public class DeleteRoleDomainResponse
    {
        [DataMember(Order = 1)]
        public required string RoleId { get; set; }
    }
}
