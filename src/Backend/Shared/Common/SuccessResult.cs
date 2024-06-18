using Shared.Common.Bases;

namespace Shared.Common
{
  public class SuccessResult<Type> : Result
  {
    public Type? Data { get; internal set; }

    public SuccessResult(Type data)
      : base(true, data) { }

    public SuccessResult()
      : base(true, default) { }
  }
}
