namespace AccessControl.Application.Interfaces
{
  public interface IMessageService
  {
    void SendConfirmationEmail(string name, string email, string token);
    void SendPasswordRecoveryEmail(string name, string email, string token);
  }
}
