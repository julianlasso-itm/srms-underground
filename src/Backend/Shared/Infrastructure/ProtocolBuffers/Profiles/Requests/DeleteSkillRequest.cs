using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
    [DataContract]
    public class DeleteSkillRequest
    {
        [DataMember(Order = 1)]    
        public required string SkillId { get; set; }
    }
}
