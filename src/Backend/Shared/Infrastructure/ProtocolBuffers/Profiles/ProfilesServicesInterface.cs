// Licensed to the .NET Foundation under one or more agreements.

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Shared.Infrastructure.ProtocolBuffers.Profiles
{
    [ServiceContract]
    public interface IProfilesServices
    {
        [OperationContract]
        Task<DeleteSkillResponse> DeleteSkillAsync(DeleteSkillRequest request, CallContext context = default);

        [OperationContract]
        Task<GetSkillsResponse> GetSkillAsync(GetSkillsRequest request, CallContext context = default);

        [OperationContract]
        Task<RegisterSkillResponse> RegisterSkillAsync(RegisterSkillRequest request, CallContext context = default);

        [OperationContract]
        Task<UpdateSkillResponse> UpdateSkillRoleAsync(UpdateSkillRequest request, CallContext context = default);
    }
}
