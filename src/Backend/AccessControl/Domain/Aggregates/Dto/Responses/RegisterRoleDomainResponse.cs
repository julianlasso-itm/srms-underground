using AccessControl.Domain.Aggregates.Dto.Responses.Bases;
using AccessControl.Domain.Aggregates.Dto.Responses.Interfaces;

namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public class RegisterRoleDomainResponse : DomainResponse
  {
    public required string RoleId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required bool Disabled { get; init; }

    public override Type Accept<Type>(IDomainResponseVisitor<Type> visitor)
    {
      return visitor.Visit(this);
    }
  }
}
