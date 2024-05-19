using System.Net.Mail;
using System.Net;
using AccessControl.Application.Interfaces;
using System.Web;

namespace AccessControl.Infrastructure.Services
{
  public class MessageService : IMessageService
  {
    private readonly IConfiguration _configuration;
    private string? SmtpServer;
    private int SmtpPort;
    private string? SmtpUsername;
    private string? SmtpPassword;
    private string? FrontendUrl;
    private SmtpClient _smtpClient;

    public MessageService(IConfiguration configuration)
    {
      _configuration = configuration;
      var emailSettings = _configuration.GetSection("EmailSettings");
      SmtpServer = emailSettings.GetValue<string>("SmtpServer");
      SmtpPort = emailSettings.GetValue<int>("SmtpPort");
      SmtpUsername = emailSettings.GetValue<string>("SmtpUsername");
      SmtpPassword = emailSettings.GetValue<string>("SmtpPassword");
      FrontendUrl = emailSettings.GetValue<string>("FrontendUrl");

      _smtpClient = new SmtpClient(SmtpServer)
      {
        Port = SmtpPort,
        Credentials = new NetworkCredential(SmtpUsername, SmtpPassword),
        EnableSsl = true
      };
    }

    public void SendConfirmationEmail(string name, string email, string token)
    {

      try
      {
        var message = new MailMessage
        {
          From = new MailAddress(SmtpUsername!),
          Subject = "Confirmación de inicio de sesión",
          Body = $@"
                <!DOCTYPE html>
                <html lang=""es"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Confirmación de inicio de sesión</title>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: #f9f9f9;
                            padding: 20px;
                        }}
                        h1 {{
                            color: #333;
                        }}
                        p {{
                            font-size: 16px;
                            line-height: 1.6;
                        }}
                        strong {{
                            color: #007bff;
                        }}
                    </style>
                </head>
                <body>
                    <h1>Hola {name},</h1>
                    <p>Para verificar tu sesión, haz clic en el siguiente enlace:</p>
                    <p><a href=""{FrontendUrl}/security/verify-email/{HttpUtility.UrlEncode(token)}"">Verificar sesión</a></p>
                    <p>¡Gracias por usar nuestro servicio!</p>
                </body>
                </html>",
          IsBodyHtml = true
        };

        message.To.Add(email);
        _smtpClient.Send(message);

        Console.WriteLine("Correo de confirmación enviado con éxito.");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error al enviar el correo: {ex.Message}");
      }
    }

    public void SendPasswordRecoveryEmail(string name, string email, string token)
    {
      try
      {
        var message = new MailMessage
        {
          From = new MailAddress(SmtpUsername!),
          Subject = "Recuperación de contraseña",
          Body = $@"
            <!DOCTYPE html>
            <html lang=""es"">
            <head>
                <meta charset=""UTF-8"">
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <title>Recuperación de contraseña</title>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                        background-color: #f9f9f9;
                        padding: 20px;
                    }}
                    h1 {{
                        color: #333;
                    }}
                    p {{
                        font-size: 16px;
                        line-height: 1.6;
                    }}
                    strong {{
                        color: #007bff;
                    }}
                </style>
            </head>
            <body>
                <h1>Hola {name},</h1>
                <p>Para recuperar tu contraseña, haz clic en el siguiente enlace:</p>
                <p><a href=""{FrontendUrl}/security/reset-password/{HttpUtility.UrlEncode(token)}"">Recuperar contraseña</a></p>
                <p>¡Gracias por usar nuestro servicio!</p>
            </body>
            </html>",
          IsBodyHtml = true
        };

        message.To.Add(email);
        _smtpClient.Send(message);

        Console.WriteLine("Correo de recuperación de contraseña enviado con éxito.");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error al enviar el correo: {ex.Message}");
      }
    }
  }
}
