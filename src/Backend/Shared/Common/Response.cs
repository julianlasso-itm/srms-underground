using Shared.Common.Bases;
using Shared.Common.Enums;

namespace Shared.Common
{
  public class Response<Type>
  {
    public static Result<Type> Success(Type data)
    {
      return new SuccessResult<Type>(data);
    }

    public static Result<Type> Success()
    {
      return new SuccessResult<Type>();
    }

    public static Result<Type> Failure(string message, ErrorEnum code)
    {
      return new ErrorResult<Type>(message, code);
    }

    public static Result<Type> Failure(string? message, ErrorEnum? code, object? details)
    {
      return new ErrorResult<Type>(
        message ?? string.Empty,
        code ?? ErrorEnum.INTERNAL_SERVER_ERROR,
        details ?? new object()
      );
    }
  }
}
