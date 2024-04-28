using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Helpers;

namespace Profiles.Domain.Aggregates.Interfaces;

public class AccountAggregate : IAccountAggregate
{
    public DeleteCityDomainResponse DeleteCity(DeleteCityDomainRequest request)
    {
        return DeleteCityHelper.Execute(request);
    }

    public DeleteCountryDomainResponse DeleteCountry(DeleteCountryDomainRequest request)
    {
        return DeleteCountryHelper.Execute(request);
    }

    public DeleteProvinceDomainResponse DeleteProvince(DeleteProvinceDomainRequest request)
    {
        return DeleteProvinceHelper.Execute(request);
    }

    public RegisterCityDomainResponse RegisterCity(RegisterCityDomainRequest request)
    {
        return RegisterCityHelper.Execute(request);
    }

    public RegisterCountryDomainResponse RegisterCountry(RegisterCountryDomainRequest request)
    {
        return RegisterCountryHelper.Execute(request);
    }

    public RegisterProvinceDomainResponse RegisterProvince(RegisterProvinceDomainRequest request)
    {
        return RegisterProvinceHelper.Execute(request);
    }

    public UpdateCityDomainResponse UpdateCity(UpdateCityDomainRequest request)
    {
        return UpdateCityHelper.Execute(request);
    }

    public UpdateCountryDomainResponse UpdateCountry(UpdateCountryDomainRequest request)
    {
        return UpdateCountryHelper.Execute(request);
    }

    public UpdateProvinceDomainResponse UpdateProvince(UpdateProvinceDomainRequest request)
    {
        return UpdateProvinceHelper.Execute(request);
    }
}
