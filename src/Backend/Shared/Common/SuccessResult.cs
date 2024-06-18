using Shared.Common.Bases;

namespace Shared.Common
{
  public class SuccessResult<Type> : Result
  {
    public Type Data { get; private set; }

    public SuccessResult(Type data)
    {
      IsSuccess = true;
      Data = data;
    }

    public SuccessResult()
    {
      IsSuccess = true;
    }
  }

  public class SuccessResult : Result
  {
    public SuccessResult()
    {
      IsSuccess = true;
    }
  }
}
