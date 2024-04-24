// Licensed to the .NET Foundation under one or more agreements.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiles.Application.Responses
{
    public class RegisterSkillApplicationResponse
    {
        public required string SkillId { get; init; }
        public required string Name { get; init; }
        public required bool Disabled { get; init; }
    }
}
