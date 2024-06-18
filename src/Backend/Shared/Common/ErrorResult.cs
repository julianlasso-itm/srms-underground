using Shared.Common.Bases;
using Shared.Common.Enums;

namespace Shared.Common
{
  public class ErrorResult : Result
  {
    public ErrorResult(string message, ErrorEnum code, object? details)
      : base(false, details)
    {
      Message = message;
      Code = code;
      Details = details;
    }
  }
}
