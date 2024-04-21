using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers;

internal abstract class UpdateCountryHelper
    : BaseHelper,
        IHelper<UpdateCountryDomainRequest, UpdateCountryDomainResponse>
{
    public static UpdateCountryDomainResponse Execute(UpdateCountryDomainRequest data)
    {
        throw new NotImplementedException();
    }
}
