// Licensed to the .NET Foundation under one or more agreements.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
    [DataContract]
    public class GetSkillsResponse
    {

        [DataMember(Order = 1)]
        public required IEnumerable<SkillContract> Skills { get; set; }

        [DataMember(Order = 2)]
        public required int Total { get; set; }
    }

    [DataContract]
    public class SkillContract
    {
        [DataMember(Order = 1)]
        public required string SkillId { get; set; }

        [DataMember(Order = 2)]
        public required string Name { get; set; }

        [DataMember(Order = 3)]
        public required bool Disabled { get; set; }
    }
}
