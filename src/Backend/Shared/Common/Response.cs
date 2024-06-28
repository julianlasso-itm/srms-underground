using Shared.Common.Bases;
using Shared.Common.Enums;

namespace Shared.Common
{
  public class Response<Type>
  {
    public static Result<Type> Success(Type data)
    {
      return new Result<Type> { IsSuccess = true, Data = data };
    }

    public static Result<Type> Success()
    {
      return new Result<Type> { IsSuccess = true };
    }

    public static Result<Type> Failure(string message, ErrorEnum code)
    {
      return new Result<Type>
      {
        IsSuccess = false,
        Message = message,
        Code = code
      };
    }

    public static Result<Type> Failure(string? message, ErrorEnum? code, object? details)
    {
      return new Result<Type>
      {
        IsSuccess = false,
        Message = message,
        Code = code,
        Details = details
      };
    }
  }
}
