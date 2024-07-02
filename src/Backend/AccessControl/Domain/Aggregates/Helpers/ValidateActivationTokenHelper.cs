using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.ValueObjects;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal class ValidateActivationTokenHelper
    : BaseHelper,
      IHelper<ActivateTokenDomainRequest, ActivateTokenDomainResponse>
  {
    public static Result<ActivateTokenDomainResponse> Execute(ActivateTokenDomainRequest request)
    {
      var activationToken = new ActivationTokenValueObject(request.ActivationToken);
      var record = new { activationToken };

      var resultValidation = ValidateRecordFields(record);
      if (resultValidation.IsFailure)
      {
        return Response<ActivateTokenDomainResponse>.Failure(
          resultValidation.Message,
          resultValidation.Code,
          resultValidation.Details
        );
      }

      return Response<ActivateTokenDomainResponse>.Success(MapToResponse(activationToken));
    }

    private static ActivateTokenDomainResponse MapToResponse(
      ActivationTokenValueObject activationToken
    )
    {
      return new ActivateTokenDomainResponse { ActivationToken = activationToken.Value };
    }
  }
}
