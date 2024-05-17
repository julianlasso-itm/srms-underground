using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class RegisterProfessionalHelper
    : BaseHelper,
      IHelper<RegisterProfessionalDomainRequest, RegisterProfessionalDomainResponse>
  {
    public static RegisterProfessionalDomainResponse Execute(RegisterProfessionalDomainRequest data)
    {
      var record = GetProfessional(data);
      ValidateRecordFields(record);

      var professional = new ProfessionalEntity();
      professional.Register(record.Name, record.Email);

      return new RegisterProfessionalDomainResponse
      {
        ProfessionalId = professional.ProfessionalId.Value,
        Name = professional.Name.Value,
        Email = professional.Email.Value,
        Disabled = professional.Disabled.Value
      };
    }

    private static ProfessionalRecord GetProfessional(RegisterProfessionalDomainRequest data)
    {
      var name = new NameValueObject(data.Name);
      var email = new EmailValueObject(data.Email);

      return new ProfessionalRecord { Name = name, Email = email };
    }
  }
}
