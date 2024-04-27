using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
    [DataContract]
    public class GetSkillsRequest
    {
        [DataMember(Order = 1)]
        public int Page { get; set; }

        [DataMember(Order = 2)]
        public int Limit { get; set; }

        [DataMember(Order = 3, IsRequired = false)]
        public string? Filter { get; set; }

        [DataMember(Order = 4, IsRequired = false)]
        public string? Sort { get; set; }

        [DataMember(Order = 5, IsRequired = false)]
        public string? Order { get; set; } = "asc";
    }
}
