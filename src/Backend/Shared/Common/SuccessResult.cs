using Shared.Common.Bases;

namespace Shared.Common
{
  public class SuccessResult<Type> : Result
  {
    public Type Data { get; private set; }

    public SuccessResult(Type data)
      : base(true)
    {
      Data = data;
    }

    public SuccessResult()
      : base(true) { }
  }
}
