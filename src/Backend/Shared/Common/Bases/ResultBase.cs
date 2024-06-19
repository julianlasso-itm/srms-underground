using Shared.Common.Enums;

namespace Shared.Common.Bases
{
  public abstract class Result<Type>
  {
    public Type Data { get; protected set; }
    public bool IsSuccess { get; protected set; }
    public bool IsFailure => !IsSuccess;
    public string? Message { get; protected set; }
    public ErrorEnum? Code { get; protected set; }
    public object? Details { get; protected set; }
  }
}
