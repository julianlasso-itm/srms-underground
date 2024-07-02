using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.ValueObjects;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class ResetPasswordHelper
    : BaseHelper,
      IHelper<ResetPasswordDomainRequest, ResetPasswordDomainResponse>
  {
    public static Result<ResetPasswordDomainResponse> Execute(ResetPasswordDomainRequest data)
    {
      var record = new ResetPasswordRecord { Password = new PasswordValueObject(data.Password) };
      var resultValidation = ValidateRecordFields(record);
      if (resultValidation.IsFailure)
      {
        return Response<ResetPasswordDomainResponse>.Failure(
          resultValidation.Message,
          resultValidation.Code,
          resultValidation.Details
        );
      }

      return Response<ResetPasswordDomainResponse>.Success(
        new ResetPasswordDomainResponse { Password = record.Password.Value }
      );
    }
  }
}
