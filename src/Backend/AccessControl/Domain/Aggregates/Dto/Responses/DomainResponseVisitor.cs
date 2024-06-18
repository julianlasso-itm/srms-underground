using AccessControl.Domain.Aggregates.Dto.Responses.Bases;
using AccessControl.Domain.Aggregates.Dto.Responses.Interfaces;

namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public class DomainResponseVisitor : IDomainResponseVisitor<DomainResponse>
  {
    public DomainResponse Visit(ActivateTokenDomainResponse response)
    {
      return response;
    }

    public DomainResponse Visit(ActiveCredentialDomainResponse response)
    {
      return response;
    }

    public DomainResponse Visit(ChangePasswordDomainResponse response)
    {
      return response;
    }

    public DomainResponse Visit(DeleteRoleDomainResponse response)
    {
      return response;
    }

    public DomainResponse Visit(PasswordRecoveryDomainResponse response)
    {
      return response;
    }

    public DomainResponse Visit(RegisterCredentialDomainResponse response)
    {
      return response;
    }

    public DomainResponse Visit(RegisterRoleDomainResponse response)
    {
      return response;
    }

    public DomainResponse Visit(ResetPasswordDomainResponse response)
    {
      return response;
    }

    public DomainResponse Visit(SignInDataInitialsDomainResponse response)
    {
      return response;
    }

    public DomainResponse Visit(SignInDomainResponse response)
    {
      return response;
    }

    public DomainResponse Visit(UpdateCredentialDomainResponse response)
    {
      return response;
    }

    public DomainResponse Visit(UpdateRoleDomainResponse response)
    {
      return response;
    }

    public DomainResponse Visit(VerifyTokenDomainResponse response)
    {
      return response;
    }
  }
}
