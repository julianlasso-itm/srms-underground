using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities.Structs
{
    public struct SkillStruct
    {
       
        public SkillIdValueObject SkillId { get; set; }
        public DisabledValueObject Disabled { get; set; }
        public NameValueObject Name { get; set; }
    }
}
