using Shared.Common.Enums;

namespace Shared.Common.Bases
{
  public abstract class Result(
    object data,
    bool isSuccess,
    string? message = null,
    ErrorEnum? code = null,
    object? details = null
  )
  {
    public object Data { get; protected set; } = data;
    public bool IsSuccess { get; private set; } = isSuccess;
    public bool IsFailure => !IsSuccess;
    public string? Message { get; protected set; } = message;
    public ErrorEnum? Code { get; protected set; } = code;
    public object? Details { get; protected set; } = details;
  }
}
