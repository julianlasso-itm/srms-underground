using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers;

internal abstract class DeleteCountryHelper
    : BaseHelper,
        IHelper<DeleteCountryDomainRequest, DeleteCountryDomainResponse>
{
    public static DeleteCountryDomainResponse Execute(DeleteCountryDomainRequest data)
    {
        throw new NotImplementedException();
    }
}
