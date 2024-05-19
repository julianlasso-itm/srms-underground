using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Dto.Responses;

namespace AccessControl.Application.AntiCorruption.Interfaces
{
  public interface IDomainToApplication
  {
    public RegisterUserApplicationResponse ToRegisterUserApplicationResponse(
      RegisterCredentialDomainResponse user,
      string cityId
    );
    public GetRolesApplicationResponse<TEntity> ToGetRolesApplicationResponse<TEntity>(
      IEnumerable<TEntity> roles,
      int total
    )
      where TEntity : class;
    public RegisterRoleApplicationResponse ToRegisterRoleApplicationResponse(
      RegisterRoleDomainResponse role
    );
    public UpdateRoleApplicationResponse ToUpdateRoleApplicationResponse(
      UpdateRoleDomainResponse role
    );
    public DeleteRoleApplicationResponse ToDeleteRoleApplicationResponse(
      DeleteRoleDomainResponse role
    );
    public ActivationTokenApplicationResponse ToActivationTokenApplicationResponse(
      ActivateTokenDomainResponse response
    );
    public SignInApplicationResponse ToSignInApplicationResponse(SignInDomainResponse response);
    public VerifyTokenApplicationResponse ToVerifyTokenApplicationResponse(
      VerifyTokenDomainResponse response,
      string userId,
      string photo
    );
    public ChangePasswordApplicationResponse ToChangePasswordApplicationResponse();
    public PasswordRecoveryApplicationResponse ToPasswordRecoveryApplicationResponse();
    public UpdateUserApplicationResponse ToUpdateUserApplicationResponse(
      UpdateCredentialDomainResponse response
    );
  }
}
