// Licensed to the .NET Foundation under one or more agreements.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiles.Domain.Aggregates.Dto.Responses
{
    public class RegisterSkillDomainResponse
    { 
        public required string SkillId { get; init; }
        public string Name { get; init; }
        public bool Disabled { get; init; }
    }
}
