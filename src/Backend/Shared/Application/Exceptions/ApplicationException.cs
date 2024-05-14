using System.Net;

namespace Shared.Application.Exceptions
{
  public class ApplicationException : Exception
  {
    public HttpStatusCode StatusCode { get; private set; }

    public ApplicationException(string message)
      : base(message)
    {
      StatusCode = HttpStatusCode.InternalServerError;
    }

    public ApplicationException(string message, Exception innerException)
      : base(message, innerException)
    {
      StatusCode = HttpStatusCode.InternalServerError;
    }

    public ApplicationException(string message, HttpStatusCode statusCode)
      : base(message)
    {
      StatusCode = statusCode;
    }

    public ApplicationException(string message, HttpStatusCode statusCode, Exception innerException)
      : base(message, innerException)
    {
      StatusCode = statusCode;
    }
  }
}
