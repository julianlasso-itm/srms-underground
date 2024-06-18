using AccessControl.Domain.Aggregates.Dto.Responses.Bases;
using AccessControl.Domain.Aggregates.Dto.Responses.Interfaces;

namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public class UpdateRoleDomainResponse : DomainResponse
  {
    public required string RoleId { get; init; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? Disabled { get; set; }

    public override Type Accept<Type>(IDomainResponseVisitor<Type> visitor)
    {
      return visitor.Visit(this);
    }
  }
}
