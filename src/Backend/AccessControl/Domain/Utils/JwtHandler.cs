using System.Security.Cryptography;
using System.Text;

namespace AccessControl.Domain.Utils
{
  public class JwtHandler
  {
    private readonly string _secretKey;

    public JwtHandler(string secretKey)
    {
      this._secretKey = secretKey;
    }

    public string GenerateToken(JwtPayload payload)
    {
      var header = "{\"alg\":\"HS256\",\"typ\":\"JWT\"}";
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
      var signature = CreateSignature(parts[0], parts[1]);
      return signature == parts[2];
    }

    public JwtPayload DecodeToken(string token)
    {
      var parts = token.Split('.');
      if (parts.Length != 3 || !VerifyToken(token))
      {
        throw new Exception("Invalid token");
      }
      var payload = Encoding.UTF8.GetString(Base64UrlDecode(parts[1]));
      return DeserializePayload(payload);
    }

    private string CreateSignature(string header, string payload)
    {
      var data = $"{header}.{payload}";
      using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_secretKey));
      var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
      return Base64UrlEncode(hash);
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
      return $"{{\"TokenId\":\"{payload.TokenId}\",\"FullName\":\"{payload.FullName}\",\"Email\":\"{payload.Email}\",\"Photo\":\"{payload.Photo}\",\"Expiration\":\"{payload.Expiration}\"}}";
    }

    private static JwtPayload DeserializePayload(string json)
    {
      json = json.Trim(new char[] { '{', '}' });
      var keyValuePairs = json.Split(',');
      var payload = new JwtPayload();
      foreach (var kvp in keyValuePairs)
      {
        var split = kvp.Split(':');
        var key = split[0].Trim('\"');
        var value = split[1].Trim('\"');
        switch (key)
        {
          case "TokenId":
            payload.TokenId = value;
            break;
          case "FullName":
            payload.FullName = value;
            break;
          case "Email":
            payload.Email = value;
            break;
          case "Photo":
            payload.Photo = value;
            break;
          case "Expiration":
            payload.Expiration = DateTime.Parse(value);
            break;
        }
      }
      return payload;
    }
  }
}
