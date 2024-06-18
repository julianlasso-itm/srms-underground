using AccessControl.Domain.Aggregates.Dto.Responses.Bases;
using AccessControl.Domain.Aggregates.Dto.Responses.Interfaces;

namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public class DeleteRoleDomainResponse : DomainResponse
  {
    public required string RoleId { get; init; }

    public override Type Accept<Type>(IDomainResponseVisitor<Type> visitor)
    {
      return visitor.Visit(this);
    }
  }
}
