using AccessControl.Domain.Aggregates.Dto.Responses.Bases;
using AccessControl.Domain.Aggregates.Dto.Responses.Interfaces;

namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public sealed class SignInDomainResponse : DomainResponse
  {
    public required string Token { get; init; }

    public override Type Accept<Type>(IDomainResponseVisitor<Type> visitor)
    {
      return visitor.Visit(this);
    }
  }
}
