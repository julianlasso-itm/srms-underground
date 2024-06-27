using System.Net;
using System.Text.Json;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Shared.Domain.Exceptions;
using Shared.Infrastructure.Exceptions;
using ApplicationException = Shared.Application.Exceptions.ApplicationException;

namespace Shared.Infrastructure.Interceptors
{
  public class ErrorHandlingInterceptor : Interceptor
  {
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
      TRequest request,
      ServerCallContext context,
      UnaryServerMethod<TRequest, TResponse> continuation
    )
    {
      try
      {
        var result = await continuation(request, context);
        return result;
      }
      catch (RpcException exception)
      {
        Console.WriteLine($"RpcException: {exception.Status.Detail}");
        throw;
      }
      catch (DomainException exception)
      {
        var message = JsonSerializer.Serialize(
          new { Message = exception.Message, Errors = exception.DomainErrors },
          options: new JsonSerializerOptions { WriteIndented = true }
        );
        throw new RpcException(
          new Status(
            StatusCodeConverter.GetGrpcStatusCodeFromHttpStatusCode(HttpStatusCode.BadRequest),
            message
          )
        );
      }
      catch (ApplicationException exception)
      {
        var message = JsonSerializer.Serialize(
          new { Message = exception.Message },
          options: new JsonSerializerOptions { WriteIndented = true }
        );
        throw new RpcException(
          new Status(
            StatusCodeConverter.GetGrpcStatusCodeFromHttpStatusCode(exception.StatusCode),
            message
          )
        );
      }
      catch (Exception exception)
      {
        throw new RpcException(new Status(StatusCode.Internal, exception.Message));
      }
    }
  }
}
