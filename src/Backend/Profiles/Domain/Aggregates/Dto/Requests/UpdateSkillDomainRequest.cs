// Licensed to the .NET Foundation under one or more agreements.

namespace Profiles.Domain.Aggregates.Dto.Requests
{
    public class UpdateSkillDomainRequest
    {
        public  string? Name { get; init; }
        public  bool? Disable { get; init; }
        public required string SkillId { get; init; }
    }
}
