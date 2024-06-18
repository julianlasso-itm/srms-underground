using AccessControl.Domain.Aggregates.Dto.Responses.Bases;
using AccessControl.Domain.Aggregates.Dto.Responses.Interfaces;

namespace AccessControl.Domain.Aggregates.Dto.Responses
{
  public sealed class UpdateCredentialDomainResponse : DomainResponse
  {
    public string CredentialId { get; set; }
    public string? Name { get; set; }
    public byte[]? Avatar { get; set; }
    public string? AvatarExtension { get; set; }
    public string? Photo { get; set; }
    public bool? Disabled { get; set; }
    public string? CityId { get; set; }

    public override Type Accept<Type>(IDomainResponseVisitor<Type> visitor)
    {
      return visitor.Visit(this);
    }
  }
}
