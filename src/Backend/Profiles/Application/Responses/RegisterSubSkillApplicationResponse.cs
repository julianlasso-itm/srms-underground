﻿namespace Profiles.Application.Responses
{
  public class RegisterSubSkillApplicationResponse
  {
    public required string SubSkillId { get; init; }
    public required string SkillId { get; init; }
    public required string Name { get; init; }
    public required bool Disabled { get; init; }
  }
}
