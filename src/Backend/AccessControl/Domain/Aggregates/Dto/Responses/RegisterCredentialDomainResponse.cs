using AccessControl.Domain.Aggregates.Dto.Responses.Bases;
using AccessControl.Domain.Aggregates.Dto.Responses.Interfaces;

namespace AccessControl.Domain.Aggregates.Dto.Responses;

public class RegisterCredentialDomainResponse : DomainResponse
{
  public required string CredentialId { get; init; }
  public required string Name { get; init; }
  public required string Email { get; init; }
  public required string Password { get; init; }
  public required byte[] Avatar { get; init; }
  public required string AvatarExtension { get; init; }
  public required string Photo { get; set; }
  public required string[] Roles { get; init; }
  public required bool Disabled { get; init; }

  public override Type Accept<Type>(IDomainResponseVisitor<Type> visitor)
  {
    return visitor.Visit(this);
  }
}
