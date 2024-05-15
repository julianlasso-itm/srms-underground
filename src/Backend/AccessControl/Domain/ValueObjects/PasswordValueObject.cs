using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace AccessControl.Domain.ValueObjects;

public sealed class PasswordValueObject : BaseStringValueObject
{
  public new string Value
  {
    get => CreateSha512Hash(base.Value);
  }

  private const int MinLength = 8;
  private const string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";

  public PasswordValueObject(string value, bool validate = true)
    : base(value)
  {
    Name = "Password";
    if (validate)
    {
      Validate();
    }
  }

  public override void Validate()
  {
    base.Validate();
    if (!IsLengthValid(Value))
    {
      AddError(new ErrorValueObject(Name, $"{Name} must be at least {MinLength} characters"));
    }
    else if (IsPasswordValid(Value)) // TODO: Fix this
    {
      AddError(
        new ErrorValueObject(
          Name,
          $"{Name} must contain at least one uppercase letter, one lowercase letter, and one number"
        )
      );
    }
  }

  private static bool IsLengthValid(string value)
  {
    return value.Length >= MinLength;
  }

  private static bool IsPasswordValid(string value)
  {
    return Regex.IsMatch(value, PasswordRegex);
  }

  private static string CreateSha512Hash(string value)
  {
    var bytes = Encoding.UTF8.GetBytes(value);
    var hash = SHA512.HashData(bytes);
    var stringBuilder = new StringBuilder();
    foreach (var hashByte in hash)
    {
      stringBuilder.Append(hashByte.ToString("X2"));
    }
    return stringBuilder.ToString();
  }
}
