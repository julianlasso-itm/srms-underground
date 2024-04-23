using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Interfaces;

public interface IAccountAggregate : IAggregate
{
    RegisterCountryDomainResponse RegisterCountry(RegisterCountryDomainRequest request);
    UpdateCountryDomainResponse UpdateCountry(UpdateCountryDomainRequest request);
    DeleteCountryDomainResponse DeleteCountry(DeleteCountryDomainRequest request);
}
