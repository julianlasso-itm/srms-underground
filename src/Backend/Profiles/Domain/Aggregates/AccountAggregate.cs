using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Helpers;

namespace Profiles.Domain.Aggregates.Interfaces;

public class AccountAggregate : IAccountAggregate
{
    public DeleteCountryDomainResponse DeleteCountry(DeleteCountryDomainRequest request)
    {
        return DeleteCountryHelper.Execute(request);
    }

    public RegisterCountryDomainResponse RegisterCountry(RegisterCountryDomainRequest request)
    {
        return RegisterCountryHelper.Execute(request);
    }

    public UpdateCountryDomainResponse UpdateCountry(UpdateCountryDomainRequest request)
    {
        return UpdateCountryHelper.Execute(request);
    }
}
