namespace AccessControl.Domain.Aggregates.Dto.Responses.Interfaces
{
  public interface IDomainResponseVisitor<Type>
  {
    Type Visit(ActivateTokenDomainResponse response);
    Type Visit(ActiveCredentialDomainResponse response);
    Type Visit(ChangePasswordDomainResponse response);
    Type Visit(DeleteRoleDomainResponse response);
    Type Visit(PasswordRecoveryDomainResponse response);
    Type Visit(RegisterCredentialDomainResponse response);
    Type Visit(RegisterRoleDomainResponse response);
    Type Visit(ResetPasswordDomainResponse response);
    Type Visit(SignInDataInitialsDomainResponse response);
    Type Visit(SignInDomainResponse response);
    Type Visit(UpdateCredentialDomainResponse response);
    Type Visit(UpdateRoleDomainResponse response);
    Type Visit(VerifyTokenDomainResponse response);
  }
}
