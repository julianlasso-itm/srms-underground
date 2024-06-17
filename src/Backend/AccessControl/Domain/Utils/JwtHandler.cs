using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Shared.Domain.Exceptions;

namespace AccessControl.Domain.Utils
{
  public class JwtHandler
  {
    private readonly RSA _privateKey;
    private readonly RSA _publicKey;

    public JwtHandler(string privateKeyPath, string publicKeyPath)
    {
      _privateKey = RSA.Create();
      _privateKey.ImportFromPem(File.ReadAllText(privateKeyPath));

      _publicKey = RSA.Create();
      _publicKey.ImportFromPem(File.ReadAllText(publicKeyPath));
    }

    public string GenerateToken(JwtPayload payload)
    {
      var header = "{\"alg\":\"RS256\",\"typ\":\"JWT\"}";
      var encodedHeader = Base64UrlEncode(Encoding.UTF8.GetBytes(header));
      var encodedPayload = Base64UrlEncode(Encoding.UTF8.GetBytes(SerializePayload(payload)));
      var signature = CreateSignature(encodedHeader, encodedPayload);
      return $"{encodedHeader}.{encodedPayload}.{signature}";
    }

    public bool VerifyToken(string token)
    {
      var parts = token.Split('.');
      if (parts.Length != 3)
      {
        return false;
      }
      var header = parts[0];
      var payload = parts[1];
      var signature = Base64UrlDecode(parts[2]);
      return VerifySignature($"{header}.{payload}", signature);
    }

    public JwtPayload DecodeToken(string token)
    {
      var parts = token.Split('.');
      if (parts.Length != 3 || !VerifyToken(token))
      {
        throw new DomainException("Invalid payload", [new("Payload", "Invalid payload")]);
      }
      var payloadJson = Encoding.UTF8.GetString(Base64UrlDecode(parts[1]));
      return DeserializePayload(payloadJson);
    }

    private string CreateSignature(string header, string payload)
    {
      var data = $"{header}.{payload}";
      using var sha256 = SHA256.Create();
      var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
      var signedData = _privateKey.SignHash(
        hash,
        HashAlgorithmName.SHA256,
        RSASignaturePadding.Pkcs1
      );
      return Base64UrlEncode(signedData);
    }

    private bool VerifySignature(string data, byte[] signature)
    {
      using var sha256 = SHA256.Create();
      var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
      return _publicKey.VerifyHash(
        hash,
        signature,
        HashAlgorithmName.SHA256,
        RSASignaturePadding.Pkcs1
      );
    }

    private static string Base64UrlEncode(byte[] input)
    {
      var output = Convert.ToBase64String(input);
      output = output.Split('=')[0];
      output = output.Replace('+', '-');
      output = output.Replace('/', '_');
      return output;
    }

    private static byte[] Base64UrlDecode(string input)
    {
      var output = input;
      output = output.Replace('-', '+');
      output = output.Replace('_', '/');
      switch (output.Length % 4)
      {
        case 0:
          break;
        case 2:
          output += "==";
          break;
        case 3:
          output += "=";
          break;
        default:
          throw new Exception("Illegal base64url string!");
      }
      return Convert.FromBase64String(output);
    }

    private static string SerializePayload(JwtPayload payload)
    {
      return JsonSerializer.Serialize(payload);
    }

    private static JwtPayload DeserializePayload(string json)
    {
      return JsonSerializer.Deserialize<JwtPayload>(json)
        ?? throw new DomainException("Invalid payload", [new("Payload", "Invalid payload")]);
    }
  }
}
