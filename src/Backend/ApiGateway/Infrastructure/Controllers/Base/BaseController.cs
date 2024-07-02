using System.ComponentModel;
using System.Net;
using System.Text.Json;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Shared.Application.Interfaces;
using Shared.Infrastructure.Exceptions;
using Shared.Infrastructure.ProtocolBuffers.Interfaces;

namespace ApiGateway.Infrastructure.Controllers.Base
{
  public abstract class BaseController(ICacheService cacheService) : Controller
  {
    const string ContentType = "application/json";
    protected readonly ICacheService CacheService = cacheService;

    [NonAction]
    protected IActionResult Handle<Type>(Type result)
    {
      try
      {
        return Ok(result);
        // if (result.IsFailure)
        // {
        //   var message = result.ErrorMessage ?? string.Empty;
        //   if (result.ErrorDetails != null)
        //   {
        //     message += JsonSerializer.Serialize(result.ErrorDetails);
        //   }
        //   return HandleExceptionResponse(
        //     message,
        //     result.ErrorCode != null
        //       ? Convert.ToInt32(result.ErrorCode)
        //       : Convert.ToInt32(HttpStatusCode.InternalServerError)
        //   );
        // }
        // return Ok(result.Data);
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
        Convert.ToInt32(StatusCodeConverter.GetHttpStatusCodeFromGrpcStatus(exception.StatusCode))
      );
    }

    private ContentResult HandleException(Exception exception)
    {
      return HandleExceptionResponse(
        exception.Message,
        Convert.ToInt32(HttpStatusCode.InternalServerError)
      );
    }

    private ContentResult HandleExceptionResponse(string message, int statusCode)
    {
      var content = Content(message, ContentType);
      content.StatusCode = statusCode;
      return content;
    }
  }
}
