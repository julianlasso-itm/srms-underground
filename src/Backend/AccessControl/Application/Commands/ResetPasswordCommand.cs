namespace AccessControl.Application.Commands
{
  public class ResetPasswordCommand
  {
    public required string Token { get; set; }
    public required string Password { get; set; }
  }
}
