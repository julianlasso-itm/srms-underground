namespace AccessControl.Application.Commands
{
  public class VerifyTokenCommand
  {
    public required string Token { get; set; }
    public required string PrivateKeyPath { get; set; }
    public required string PublicKeyPath { get; set; }
  }
}
