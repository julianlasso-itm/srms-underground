// Licensed to the .NET Foundation under one or more agreements.

using System.Runtime.Serialization;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles.Responses
{
  [DataContract]
  public class DeleteProfessionalProfilesResponse
  {
    [DataMember(Order = 1)]
    public required string ProfessionalId { get; set; }
  }
}
