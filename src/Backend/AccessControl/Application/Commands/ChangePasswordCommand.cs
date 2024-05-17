namespace AccessControl.Application.Commands
{
  public class ChangePasswordCommand
  {
    public required string UserId { get; set; }
    public required string OldPassword { get; set; }
    public required string NewPassword { get; set; }
  }
}
