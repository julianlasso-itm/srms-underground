using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Application.Responses
{
    public class RegisterLevelApplicationResponse
    {
        public required string LevelId { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public required bool Disabled { get; init; }
    }
}
