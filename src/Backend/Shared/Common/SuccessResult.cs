using System.Runtime.Serialization;
using Shared.Common.Bases;

namespace Shared.Common
{
  [DataContract]
  public class SuccessResult<Type> : Result<Type>
  {
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
}
