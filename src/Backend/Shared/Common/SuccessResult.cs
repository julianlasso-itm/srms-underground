using Shared.Common.Bases;

namespace Shared.Common
{
  public class SuccessResult(object? data = null) : Result(data ?? new object(), true) { }
}
