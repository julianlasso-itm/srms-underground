using Shared.Common.Bases;
using Shared.Common.Enums;

namespace Shared.Common
{
  public class ErrorResult(string message, ErrorEnum code, object? details)
    : Result(null ?? new object(), false, message, code, details) { }
}
