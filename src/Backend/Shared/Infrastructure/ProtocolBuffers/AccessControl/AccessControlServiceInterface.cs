using System.ServiceModel;
using Infrastructure.ProtocolBuffers.AccessControl.Responses;
using ProtoBuf.Grpc;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Responses;

namespace Shared.Infrastructure.ProtocolBuffers.AccessControl
{
  [ServiceContract]
  public interface IAccessControlServices
  {
    [OperationContract]
    Task<ResultRegisterUser> RegisterUserAsync(
      RegisterUserRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<RegisterRoleAccessControlResponse>> RegisterRoleAsync(
      RegisterRoleAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<UpdateRoleAccessControlResponse>> UpdateRoleAsync(
      UpdateRoleAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<DeleteRoleAccessControlResponse>> DeleteRoleAsync(
      DeleteRoleAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<GetRolesAccessControlResponse>> GetRolesAsync(
      GetRolesAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<ActivationTokenAccessControlResponse>> ActivateTokenAsync(
      ActivationTokenAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<SignInAccessControlResponse>> SignInAsync(
      SignInAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<VerifyTokenAccessControlResponse>> VerifyTokenAsync(
      VerifyTokenAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<ChangePasswordAccessControlResponse>> ChangePasswordAsync(
      ChangePasswordAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<PasswordRecoveryAccessControlResponse>> PasswordRecoveryAsync(
      PasswordRecoveryAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<UpdateUserAccessControlResponse>> UpdateUserAsync(
      UpdateUserAccessControlRequest request,
      CallContext context = default
    );

    [OperationContract]
    Task<Result<ResetPasswordAccessControlResponse>> ResetPasswordAsync(
      ResetPasswordAccessControlRequest request,
      CallContext context = default
    );
  }
}
