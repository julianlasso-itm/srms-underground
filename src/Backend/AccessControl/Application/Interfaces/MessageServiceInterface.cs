namespace AccessControl.Application.Interfaces
{
  public interface IMessageService
  {
    void SendConfirmationEmail(string name, string email, string token);
  }
}
