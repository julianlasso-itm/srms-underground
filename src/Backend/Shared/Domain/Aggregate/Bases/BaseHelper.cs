using Shared.Common;
using Shared.Common.Bases;
using Shared.Common.Enums;
using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace Shared.Domain.Aggregate.Bases
{
  public abstract class BaseHelper
  {
    protected static Result ValidateRecordFields(object data)
    {
      var errors = new List<ErrorValueObject>();
      var type = data.GetType();

      foreach (var property in type.GetProperties())
      {
        var propertyValue = property.GetValue(data);

        if (propertyValue is BaseValueObjectErrorHandler baseValueObject)
        {
          if (!baseValueObject.IsValid())
          {
            errors.AddRange(baseValueObject.Errors);
          }
        }
      }

      if (errors.Count > 0)
      {
        return new ErrorResult("Invalid data", ErrorEnum.BAD_REQUEST, errors);
      }

      return new SuccessResult<bool>();
    }
  }
}
