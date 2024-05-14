using System.Net;
using Grpc.Core;

namespace Shared.Infrastructure.Exceptions
{
  public class StatusCodeConverter
  {
    public static HttpStatusCode GetHttpStatusCodeFromGrpcStatus(StatusCode grpcStatusCode)
    {
      return grpcStatusCode switch
      {
        StatusCode.Aborted => HttpStatusCode.Conflict,
        StatusCode.AlreadyExists => HttpStatusCode.Conflict,
        StatusCode.Cancelled => HttpStatusCode.GatewayTimeout,
        StatusCode.DataLoss => HttpStatusCode.InternalServerError,
        StatusCode.DeadlineExceeded => HttpStatusCode.GatewayTimeout,
        StatusCode.FailedPrecondition => HttpStatusCode.PreconditionFailed,
        StatusCode.InvalidArgument => HttpStatusCode.BadRequest,
        StatusCode.NotFound => HttpStatusCode.NotFound,
        StatusCode.OK => HttpStatusCode.OK,
        StatusCode.OutOfRange => HttpStatusCode.RequestedRangeNotSatisfiable,
        StatusCode.PermissionDenied => HttpStatusCode.Forbidden,
        StatusCode.ResourceExhausted => HttpStatusCode.InternalServerError,
        StatusCode.Unauthenticated => HttpStatusCode.Unauthorized,
        StatusCode.Unavailable => HttpStatusCode.ServiceUnavailable,
        StatusCode.Unimplemented => HttpStatusCode.NotImplemented,
        StatusCode.Unknown => HttpStatusCode.InternalServerError,
        _ => HttpStatusCode.InternalServerError
      };
    }

    public static StatusCode GetGrpcStatusCodeFromHttpStatusCode(HttpStatusCode httpStatusCode)
    {
      return httpStatusCode switch
      {
        HttpStatusCode.Conflict => StatusCode.Aborted,
        HttpStatusCode.BadRequest => StatusCode.InvalidArgument,
        HttpStatusCode.GatewayTimeout => StatusCode.Cancelled,
        HttpStatusCode.InternalServerError => StatusCode.Unknown,
        HttpStatusCode.NotFound => StatusCode.NotFound,
        HttpStatusCode.OK => StatusCode.OK,
        HttpStatusCode.PreconditionFailed => StatusCode.FailedPrecondition,
        HttpStatusCode.RequestedRangeNotSatisfiable => StatusCode.OutOfRange,
        HttpStatusCode.Forbidden => StatusCode.PermissionDenied,
        HttpStatusCode.ServiceUnavailable => StatusCode.Unavailable,
        HttpStatusCode.Unauthorized => StatusCode.Unauthenticated,
        HttpStatusCode.NotImplemented => StatusCode.Unimplemented,
        _ => StatusCode.Unknown
      };
    }
  }
}
