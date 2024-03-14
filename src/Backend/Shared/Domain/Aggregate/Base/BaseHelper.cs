using System.Reflection;
using Shared.Domain.Exceptions;
using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;

namespace SRMS.Shared.Domain.Aggregate.Helpers;

public abstract class BaseHelper
{
    protected static bool ValidateStructureFields(Object data)
    {
        var errors = new List<ErrorValueObject>();
        Type type = data.GetType();
        foreach (FieldInfo field in type.GetFields())
        {
            var valueObject = field.GetValue(data) as BaseValueObjectErrorHandler;
            if (valueObject != null && valueObject.IsValid() == false)
            {
                errors.AddRange(valueObject.Errors);
            }
        }

        if (errors.Count > 0) throw new DomainException("Invalid data structure", errors);

        return true;
    }
}
