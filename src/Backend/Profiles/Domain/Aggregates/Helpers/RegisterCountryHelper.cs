using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers;

internal abstract class RegisterCountryHelper
    : BaseHelper,
        IHelper<RegisterCountryDomainRequest, RegisterCountryDomainResponse>
{
    public static RegisterCountryDomainResponse Execute(RegisterCountryDomainRequest data)
    {
        throw new NotImplementedException();
    }
}
