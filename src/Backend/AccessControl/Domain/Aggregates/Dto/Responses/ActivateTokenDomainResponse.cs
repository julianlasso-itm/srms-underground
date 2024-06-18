using AccessControl.Domain.Aggregates.Dto.Responses.Bases;
using AccessControl.Domain.Aggregates.Dto.Responses.Interfaces;

namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public class ActivateTokenDomainResponse : DomainResponse
  {
    public required string ActivationToken { get; init; }

    public override Type Accept<Type>(IDomainResponseVisitor<Type> visitor)
    {
      return visitor.Visit(this);
    }
  }
}
