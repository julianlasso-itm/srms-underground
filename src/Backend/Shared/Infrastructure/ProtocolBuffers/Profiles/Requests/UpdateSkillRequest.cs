// Licensed to the .NET Foundation under one or more agreements.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Requests
{
    public class UpdateSkillRequest
    {
        public required string SkillId { get; set; }
        public string? Name { get; set; }
        public bool? Disable { get; set; }
    }
}
