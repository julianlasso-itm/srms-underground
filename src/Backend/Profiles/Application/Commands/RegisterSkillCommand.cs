using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Application.Base;
using Shared.Application.Interfaces;

namespace Profiles.Application.Commands
{
    public class RegisterSkillCommand: ICommand
    {
        public string Name { get; init; }

    }
}
