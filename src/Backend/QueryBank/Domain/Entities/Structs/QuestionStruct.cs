using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryBank.Domain.ValueObjects;

namespace QueryBank.Domain.Entities.Structs
{
    public struct QuestionStruct
    {

        public QuestionlIdValueObject QuestionId { get; set; }
        public NameValueObject Name { get; set; }
        public DisabledValueObject Disabled { get; set; }
    }
}
