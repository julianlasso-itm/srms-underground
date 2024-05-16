using System.Security.Cryptography;
using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects
{
  public class PrivateKeyPathValueObject : BaseStringValueObject
  {
    public PrivateKeyPathValueObject(string value)
      : base(value)
    {
      Name = "PrivateKeyPath";
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

      if (!IsValidRsaPrivateKeyFile(Value))
      {
        AddError(new ErrorValueObject(Name, $"{Name} does not contain a valid RSA private key."));
        return;
      }
    }

    private bool IsValidRsaPrivateKeyFile(string filePath)
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
