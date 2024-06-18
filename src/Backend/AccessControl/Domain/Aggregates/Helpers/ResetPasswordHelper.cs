using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.ValueObjects;
using Shared.Common;
using Shared.Common.Bases;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class ResetPasswordHelper : BaseHelper, IHelper<ResetPasswordDomainRequest>
  {
    public static Result Execute(ResetPasswordDomainRequest data)
    {
      var record = new ResetPasswordRecord { Password = new PasswordValueObject(data.Password) };
      var resultValidation = ValidateRecordFields(record);
      if (resultValidation.IsFailure)
      {
        return resultValidation;
      }
      return new SuccessResult(
        new ResetPasswordDomainResponse { Password = record.Password.Value }
      );
    }
  }
}
