using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBank.Application.Responses
{
    public class RegisterQuestionApplicationResponse
    {
        public required string QuestionId { get; init; }
        public required string Name { get; init; }
        public required bool Disabled { get; init; }
    }
}
