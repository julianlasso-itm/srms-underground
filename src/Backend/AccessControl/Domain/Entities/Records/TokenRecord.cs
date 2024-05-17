using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities.Records
{
  internal record TokenRecord
  {
    public JwtValueObject Jwt { get; set; }
    public required FullNameValueObject FullName { get; set; }
    public required EmailValueObject Email { get; set; }
    public required PhotoValueObject Photo { get; set; }
    public required List<RoleRecord> Roles { get; set; }
    public required PrivateKeyPathValueObject PrivateKeyPath { get; set; }
    public required PublicKeyPathValueObject PublicKeyPath { get; set; }
  }
}
