using Shared.Common.Enums;

namespace Shared.Common
{
  public class Result<Type>
  {
    public Type Data { get; set; }
    public bool IsSuccess { get; set; }
    public bool IsFailure => !IsSuccess;
    public string? Message { get; set; }
    public ErrorEnum? Code { get; set; }
    public object? Details { get; set; }
  }
}
