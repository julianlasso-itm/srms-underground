using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Application.Base;
using Shared.Application.Interfaces;

namespace QueryBank.Application.Commands
{
    public class RegisterQuestionCommand : ICommand
    {
        public string Name { get; init; }
        public object QuestionId { get; set; }
    }
}
