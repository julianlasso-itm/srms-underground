// Licensed to the .NET Foundation under one or more agreements.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Domain.ValueObjects.Base;

namespace Profiles.Domain.ValueObjects
{
    public class SkillIdValueObject : BaseIdValueObject
    {
        private object _skillId;

        public SkillIdValueObject(string value): base(value)
        {
            Name = "SkillId";
            Validate();
        }        
    }
}
