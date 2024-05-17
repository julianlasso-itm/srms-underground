using AccessControl.Application.Interfaces;

namespace AccessControl.Infrastructure.Services
{
  public class MessageService : IMessageService
  {
    public void SendConfirmationEmail(string name, string email, string token)
    {
      Console.WriteLine("=== Sending confirmation email ===");
      Console.WriteLine($"Sending confirmation email to {name} at {email} with token {token}");
      Console.WriteLine("==================================");
    }

    public void SendPasswordRecoveryEmail(string name, string email, string token)
    {
      Console.WriteLine("=== Sending confirmation email ===");
      Console.WriteLine($"Sending confirmation email to {name} at {email} with token {token}");
      Console.WriteLine("==================================");
    }
  }
}
