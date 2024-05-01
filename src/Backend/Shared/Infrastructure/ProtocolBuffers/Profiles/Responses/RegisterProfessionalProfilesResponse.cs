﻿using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class RegisterProfessionalProfilesResponse
  {
    [DataMember(Order = 1)]
    public required string Name { get; set; }

    [DataMember(Order = 2)]
    public required string Email { get; set; }

    [DataMember(Order = 3)]
    public required bool Disabled { get; set; }
  }
}
