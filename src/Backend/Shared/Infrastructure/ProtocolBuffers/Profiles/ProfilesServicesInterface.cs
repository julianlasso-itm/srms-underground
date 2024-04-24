// Licensed to the .NET Foundation under one or more agreements.

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles
{
    [ServiceContract]
    public interface IProfilesServices
    {
        [OperationContract]
        Task<RegisterSkillResponse> RegisterSkillAsync(RegisterSkillRequest request, CallContext context = default);
    }
}
