// Licensed to the .NET Foundation under one or more agreements.

using ProtoBuf;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [ProtoContract]
  public class DeleteProfessionalProfilesResponse
  {
    [ProtoMember(1)]
    public required string ProfessionalId { get; set; }
  }
}
