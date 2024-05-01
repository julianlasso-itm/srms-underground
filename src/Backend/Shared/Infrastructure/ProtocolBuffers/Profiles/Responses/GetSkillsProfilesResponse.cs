﻿using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class GetSkillsProfilesResponse
  {
    [DataMember(Order = 1)]
    public required IEnumerable<SkillProfiles> Skills { get; set; }

    [DataMember(Order = 2)]
    public required int Total { get; set; }
  }

  [DataContract]
  public class SkillProfiles
  {
    [DataMember(Order = 1)]
    public required string SkillId { get; set; }

    [DataMember(Order = 2)]
    public required string Name { get; set; }

    [DataMember(Order = 3)]
    public required bool Disabled { get; set; }
  }
}
