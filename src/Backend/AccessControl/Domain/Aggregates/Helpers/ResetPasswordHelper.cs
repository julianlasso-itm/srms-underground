using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Entities.Records;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class ResetPasswordHelper
    : BaseHelper,
      IHelper<ResetPasswordDomainRequest, ResetPasswordDomainResponse>
  {
    public static ResetPasswordDomainResponse Execute(ResetPasswordDomainRequest data)
    {
      var record = new ResetPasswordRecord { Password = new PasswordValueObject(data.Password) };
      ValidateRecordFields(record);
      return new ResetPasswordDomainResponse { Password = record.Password.Value };
    }
  }
}
