namespace AccessControl.Domain.Utils
{
  public class JwtPayload
  {
    public string TokenId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Photo { get; set; }
    public DateTime Expiration { get; set; }
  }
}
