using AccessControl.Domain.Aggregates.Dto.Responses.Bases;
using AccessControl.Domain.Aggregates.Dto.Responses.Interfaces;

namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public class ChangePasswordDomainResponse : DomainResponse
  {
    public required string CredentialId { get; set; }
    public required string OldPassword { get; set; }
    public required string NewPassword { get; set; }

    public override Type Accept<Type>(IDomainResponseVisitor<Type> visitor)
    {
      return visitor.Visit(this);
    }
  }
}
