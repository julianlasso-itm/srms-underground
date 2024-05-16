using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities.Structs
{
  internal struct TokenStruct
  {
    public JwtValueObject Jwt { get; set; }
    public required FullNameValueObject FullName { get; set; }
    public required EmailValueObject Email { get; set; }
    public required PhotoValueObject Photo { get; set; }
    public required List<RoleStruct> Roles { get; set; }
    public required PrivateKeyPathValueObject PrivateKeyPath { get; set; }
    public required PublicKeyPathValueObject PublicKeyPath { get; set; }
  }
}
