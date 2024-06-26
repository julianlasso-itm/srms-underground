using System.ComponentModel;
using System.Net;
using System.Text.Json;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Shared.Application.Interfaces;
using Shared.Common.Bases;
using Shared.Infrastructure.Exceptions;

namespace ApiGateway.Infrastructure.Controllers.Base
{
  public abstract class BaseController(ICacheService cacheService) : Controller
  {
    const string ContentType = "application/json";
    protected readonly ICacheService CacheService = cacheService;

    [NonAction]
    protected IActionResult Handle<ResultType>(Result<ResultType> result)
    {
      if (result.IsSuccess)
      {
        return Ok(result.Data);
      }
      else
      {
        var message = result.Message ?? string.Empty;
        if (result.Details != null)
        {
          message += JsonSerializer.Serialize(result.Details);
        }
        return HandleExceptionResponse(
          message,
          result.Code != null
            ? Convert.ToInt32(result.Code)
            : Convert.ToInt32(HttpStatusCode.InternalServerError)
        );
      }
      // try
      // {
      //   if (result.IsFailure)
      //   {
      //     return HandleExceptionResponse(
      //       JsonSerializer.Serialize(result.Details),
      //       result.Code != null
      //         ? Convert.ToInt32(result.Code)
      //         : Convert.ToInt32(HttpStatusCode.InternalServerError)
      //     );
      //   }
      //   return Ok(result.Data);
      // }
      // catch (RpcException exception)
      // {
      //   return HandleRpcException(exception);
      // }
      // catch (Exception exception)
      // {
      //   return HandleException(exception);
      // }
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
        (int)StatusCodeConverter.GetHttpStatusCodeFromGrpcStatus(exception.StatusCode)
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
  }
}
