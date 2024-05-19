using System.Net;
using System.Net.Mail;
using System.Web;
using AccessControl.Application.Interfaces;

namespace AccessControl.Infrastructure.Services
{
  public class MessageService : IMessageService
  {
    private readonly IConfiguration _configuration;
    private readonly string? _smtpServer;
    private readonly int _smtpPort;
    private readonly string? _smtpUsername;
    private readonly string? _smtpPassword;
    private readonly string? _frontendUrl;
    private readonly SmtpClient _smtpClient;

    public MessageService(IConfiguration configuration)
    {
      _configuration = configuration;
      var emailSettings = _configuration.GetSection("EmailSettings");
      _smtpServer = emailSettings.GetValue<string>("SmtpServer");
      _smtpPort = emailSettings.GetValue<int>("SmtpPort");
      _smtpUsername = emailSettings.GetValue<string>("SmtpUsername");
      _smtpPassword = emailSettings.GetValue<string>("SmtpPassword");
      _frontendUrl = emailSettings.GetValue<string>("FrontendUrl");

      _smtpClient = new SmtpClient(_smtpServer)
      {
        Port = _smtpPort,
        Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
        EnableSsl = true
      };
    }

    public void SendConfirmationEmail(string name, string email, string token)
    {
      try
      {
        var message = new MailMessage
        {
          From = new MailAddress(_smtpUsername!),
          Subject = "Confirmación de inicio de sesión",
          Body =
            $@"
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
                    <p><a href=""{_frontendUrl}/security/verify-email/{HttpUtility.UrlEncode(token)}"">Verificar sesión</a></p>
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
          From = new MailAddress(_smtpUsername!),
          Subject = "Recuperación de contraseña",
          Body =
            $@"
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
                <p><a href=""{_frontendUrl}/security/reset-password/{HttpUtility.UrlEncode(token)}"">Recuperar contraseña</a></p>
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
