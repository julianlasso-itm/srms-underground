using System.Security.Cryptography;
using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects
{
  public class PublicKeyPathValueObject : BaseStringValueObject
  {
    public PublicKeyPathValueObject(string value)
      : base(value)
    {
      Name = "PublicKeyPath";
      Validate();
    }

    public sealed override void Validate()
    {
      base.Validate();

      if (!File.Exists(Value))
      {
        AddError(new ErrorValueObject(Name, $"{Name} does not point to an existing file."));
        return;
      }

      if (!IsValidRsaPublicKeyFile(Value))
      {
        AddError(new ErrorValueObject(Name, $"{Name} does not contain a valid RSA public key."));
        return;
      }
    }

    private static bool IsValidRsaPublicKeyFile(string filePath)
    {
      try
      {
        var pem = File.ReadAllText(filePath);
        using var rsa = RSA.Create();
        rsa.ImportFromPem(pem.ToCharArray());
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}
