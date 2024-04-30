using Shared.Domain.Exceptions;
using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace Shared.Domain.Aggregate.Helpers
{
  public abstract class BaseHelper
  {
    protected static bool ValidateStructureFields(object data)
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
        throw new DomainException("Invalid data structure", errors);
      }

      return true;
    }
  }
}
