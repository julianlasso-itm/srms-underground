using System.ComponentModel;
using System.Net;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Infrastructure.Controllers.Base
{
  public abstract class BaseController : Controller
  {
    const string ContentType = "application/json";

    [NonAction]
    protected async Task<IActionResult> HandleAsync(Func<Task<IActionResult>> action)
    {
      try
      {
        return await action();
      }
      catch (RpcException exception)
      {
        return HandleRpcException(exception);
      }
      catch (Exception exception)
      {
        return HandleException(exception);
      }
    }

    [NonAction]
    protected void DebugRequest<T>(T request)
    {
      if (request != null)
      {
        Console.WriteLine("==================================");
        Console.WriteLine("Request:");
        foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(request))
        {
          var name = descriptor.Name;
          var value = descriptor.GetValue(request);
          Console.WriteLine("{0}={1}", name, value);
        }
        Console.WriteLine("==================================");
      }
    }

    private ContentResult HandleRpcException(RpcException exception)
    {
      return HandleExceptionResponse(
        exception.Status.Detail,
        (int)GetHttpStatusCodeFromGrpcStatus(exception.StatusCode)
      );
    }

    private ContentResult HandleException(Exception exception)
    {
      return HandleExceptionResponse(exception.Message, (int)HttpStatusCode.InternalServerError);
    }

    private ContentResult HandleExceptionResponse(string message, int statusCode)
    {
      var content = Content(message, ContentType);
      content.StatusCode = statusCode;
      return content;
    }

    private static HttpStatusCode GetHttpStatusCodeFromGrpcStatus(StatusCode grpcStatusCode)
    {
      return grpcStatusCode switch
      {
        Grpc.Core.StatusCode.Aborted => HttpStatusCode.Conflict,
        Grpc.Core.StatusCode.AlreadyExists => HttpStatusCode.Conflict,
        Grpc.Core.StatusCode.Cancelled => HttpStatusCode.GatewayTimeout,
        Grpc.Core.StatusCode.DataLoss => HttpStatusCode.InternalServerError,
        Grpc.Core.StatusCode.DeadlineExceeded => HttpStatusCode.GatewayTimeout,
        Grpc.Core.StatusCode.FailedPrecondition => HttpStatusCode.PreconditionFailed,
        Grpc.Core.StatusCode.InvalidArgument => HttpStatusCode.BadRequest,
        Grpc.Core.StatusCode.NotFound => HttpStatusCode.NotFound,
        Grpc.Core.StatusCode.OK => HttpStatusCode.OK,
        Grpc.Core.StatusCode.OutOfRange => HttpStatusCode.RequestedRangeNotSatisfiable,
        Grpc.Core.StatusCode.PermissionDenied => HttpStatusCode.Forbidden,
        Grpc.Core.StatusCode.ResourceExhausted => HttpStatusCode.InternalServerError,
        Grpc.Core.StatusCode.Unauthenticated => HttpStatusCode.Unauthorized,
        Grpc.Core.StatusCode.Unavailable => HttpStatusCode.ServiceUnavailable,
        Grpc.Core.StatusCode.Unimplemented => HttpStatusCode.NotImplemented,
        Grpc.Core.StatusCode.Unknown => HttpStatusCode.InternalServerError,
        _ => HttpStatusCode.InternalServerError
      };
    }
  }
}
