using Shared.Application;
using Shared.Domain;

namespace Shared.Infrastructure
{
  public class Result<Type>
    : IResultInfrastructure<Type>,
      IResultDomain<Type>,
      IResultApplication<Type>
  {
    public readonly Type? Value;
    public readonly string? Error;
    public readonly bool IsSuccess;

    private Result(Type? value, string? error, bool isSuccess)
    {
      Value = value;
      Error = error;
      IsSuccess = isSuccess;
    }

    public static Result<Type> Failure(string error)
    {
      return new Result<Type>(default, error, false);
    }

    public static Result<Type> Success(Type value)
    {
      return new Result<Type>(value, null, true);
    }

    IResultDomain<Type> IResultDomain<Type>.Failure(string error)
    {
      return new Result<Type>(default, error, false);
    }

    IResultApplication<Type> IResultApplication<Type>.Failure(string error)
    {
      return new Result<Type>(default, error, false);
    }

    IResultDomain<Type> IResultDomain<Type>.Success(Type value)
    {
      return new Result<Type>(value, null, true);
    }

    IResultApplication<Type> IResultApplication<Type>.Success(Type value)
    {
      return new Result<Type>(value, null, true);
    }

    IResultInfrastructure<Type> IResultInfrastructure<Type>.Failure(string error)
    {
      return new Result<Type>(default, error, false);
    }

    IResultInfrastructure<Type> IResultInfrastructure<Type>.Success(Type value)
    {
      return new Result<Type>(value, null, true);
    }
  }
}
