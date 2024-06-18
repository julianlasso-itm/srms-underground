using Shared.Common.Enums;

namespace Shared.Common.Bases
{
  public abstract class Result(bool isSuccess, dynamic? data)
  {
    private dynamic? Data { get; } = data;
    public bool IsSuccess { get; protected set; } = isSuccess;
    public bool IsFailure => !IsSuccess;
    public string? Message { get; protected set; }
    public ErrorEnum? Code { get; protected set; }
    public object? Details { get; protected set; }

    public bool GetData<Type>(out Type? data)
    {
      if (IsSuccess && this is SuccessResult<Type> successResult)
      {
        data = successResult.Data;
        return true;
      }
      data = default;
      return false;
    }

    public bool GetError(out ErrorResult? error)
    {
      if (IsFailure && this is ErrorResult errorResult)
      {
        error = errorResult;
        return true;
      }
      error = null;
      return false;
    }
  }
}
