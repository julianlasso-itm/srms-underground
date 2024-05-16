namespace AccessControl.Domain.Utils
{
  public class JwtPayload
  {
    public required string TokenId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Photo { get; set; }
    public required long Expiration { get; set; }
  }
}
