using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
    [DataContract]
    public class RegisterSkillResponse
    {
        [DataMember (Order = 1)]
        public string SkillId { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
    }
}
