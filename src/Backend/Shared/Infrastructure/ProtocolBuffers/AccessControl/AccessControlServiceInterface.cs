using System.ServiceModel;
using ProtoBuf.Grpc;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl
{
  [ServiceContract]
  public interface IAccessControlServices
  {
    [OperationContract]
    Task<RegisterUserResponse> RegisterUserAsync(
      RegisterUserRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<RegisterRoleAccessControlResponse> RegisterRoleAsync(
      RegisterRoleAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<UpdateRoleAccessControlResponse> UpdateRoleAsync(
      UpdateRoleAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<DeleteRoleAccessControlResponse> DeleteRoleAsync(
      DeleteRoleAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<GetRolesAccessControlResponse> GetRolesAsync(
      GetRolesAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<ActivationTokenAccessControlResponse> ActivateTokenAsync(
      ActivationTokenAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<SignInAccessControlResponse> SignInAsync(
      SignInAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<VerifyTokenAccessControlResponse> VerifyTokenAsync(
      VerifyTokenAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<ChangePasswordAccessControlResponse> ChangePasswordAsync(
      ChangePasswordAccessControlRequest request,
      CallContext context = default
    );
  }
}
