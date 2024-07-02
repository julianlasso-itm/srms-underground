using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Records;
using Profiles.Domain.ValueObjects;
using Shared.Common;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
  internal class RegisterProfessionalHelper
    : BaseHelper,
      IHelper<RegisterProfessionalDomainRequest, RegisterProfessionalDomainResponse>
  {
    public static Result<RegisterProfessionalDomainResponse> Execute(
      RegisterProfessionalDomainRequest data
    )
    {
      var record = GetProfessional(data);
      var response = ValidateRecordFields(record);

      if (response.IsFailure)
      {
        return Response<RegisterProfessionalDomainResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      var professional = new ProfessionalEntity();
      professional.Register(record.Name, record.Email);

      return Response<RegisterProfessionalDomainResponse>.Success(MapToResponse(professional));
    }

    private static ProfessionalRecord GetProfessional(RegisterProfessionalDomainRequest data)
    {
      var name = new NameValueObject(data.Name);
      var email = new EmailValueObject(data.Email);

      return new ProfessionalRecord { Name = name, Email = email };
    }

    private static RegisterProfessionalDomainResponse MapToResponse(ProfessionalEntity professional)
    {
      return new RegisterProfessionalDomainResponse
      {
        ProfessionalId = professional.ProfessionalId.Value,
        Name = professional.Name.Value,
        Email = professional.Email.Value,
        Disabled = professional.Disabled.Value
      };
    }
  }
}
