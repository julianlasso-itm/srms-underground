using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities.Structs
{
  public struct VerifyTokenStruct
  {
    public TokenValueObject Token { get; set; }
    public required PrivateKeyPathValueObject PrivateKeyPath { get; set; }
    public required PublicKeyPathValueObject PublicKeyPath { get; set; }
  }
}
