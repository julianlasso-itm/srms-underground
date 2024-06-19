using Shared.Common.Bases;
using Shared.Common.Enums;

namespace Shared.Common
{
  public class ErrorResult<Type> : Result<Type>
  {
    public ErrorResult(string message, ErrorEnum code)
    {
      IsSuccess = false;
      Message = message;
      Code = code;
    }

    public ErrorResult(string message, ErrorEnum code, object details)
    {
      IsSuccess = false;
      Message = message;
      Code = code;
      Details = details;
    }
  }
}
