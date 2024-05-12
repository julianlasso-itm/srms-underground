using AccessControl.Domain.Aggregates.Dto.Requests;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Helpers
{
  internal abstract class ValidateActivationTokenHelper
    : BaseHelper,
      IHelper<ActivateTokenDomainRequest, ActivateTokenDomainResponse>
  {
    public static ActivateTokenDomainResponse Execute(ActivateTokenDomainRequest request)
    {
      var activationToken = new ActivationTokenValueObject(request.ActivationToken);
      return MapToResponse(activationToken);
    }

    private static ActivateTokenDomainResponse MapToResponse(
      ActivationTokenValueObject activationToken
    )
    {
      return new ActivateTokenDomainResponse { ActivationToken = activationToken.Value };
    }
  }
}
