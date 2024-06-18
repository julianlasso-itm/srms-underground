using Shared.Common.Bases;
using Shared.Common.Enums;

namespace Shared.Common
{
  public class ErrorResult(string errorMessage, ErrorEnum errorCode, object? details = null) : Result(false)
  {
    public string Message { get; private set; } = errorMessage;
    public ErrorEnum Code { get; private set; } = errorCode;
    public object? Details { get; private set; } = details;
  }
}
