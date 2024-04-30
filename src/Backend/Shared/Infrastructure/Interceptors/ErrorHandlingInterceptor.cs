using System.Net;
using System.Text.Json;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Shared.Domain.Exceptions;

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
        return await continuation(request, context);
      }
      catch (RpcException exception)
      {
        Console.WriteLine($"RpcException: {exception.Status.Detail}");
        throw;
      }
      catch (DomainException exception)
      {
        var message = JsonSerializer.Serialize(
          new
          {
            StatusCode = HttpStatusCode.BadRequest,
            Message = exception.Message,
            Errors = exception.DomainErrors,
          },
          options: new JsonSerializerOptions { WriteIndented = true, }
        );
        throw new RpcException(new Status(StatusCode.InvalidArgument, message));
      }
      catch (Exception exception)
      {
        throw new RpcException(new Status(StatusCode.Internal, exception.Message));
      }
    }
  }
}
