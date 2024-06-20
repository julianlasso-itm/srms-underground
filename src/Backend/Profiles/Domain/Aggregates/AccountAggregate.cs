using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Helpers;
using Shared.Common.Bases;

namespace Profiles.Domain.Aggregates.Interfaces
{
  public class AccountAggregate : IAccountAggregate
  {
    public Result<DeleteCityDomainResponse> DeleteCity(DeleteCityDomainRequest request)
    {
      return DeleteCityHelper.Execute(request);
    }

    public Result<DeleteCountryDomainResponse> DeleteCountry(DeleteCountryDomainRequest request)
    {
      return DeleteCountryHelper.Execute(request);
    }

    public Result<DeleteProvinceDomainResponse> DeleteProvince(DeleteProvinceDomainRequest request)
    {
      return DeleteProvinceHelper.Execute(request);
    }

    public Result<RegisterCityDomainResponse> RegisterCity(RegisterCityDomainRequest request)
    {
      return RegisterCityHelper.Execute(request);
    }

    public Result<RegisterCountryDomainResponse> RegisterCountry(
      RegisterCountryDomainRequest request
    )
    {
      return RegisterCountryHelper.Execute(request);
    }

    public Result<RegisterProvinceDomainResponse> RegisterProvince(
      RegisterProvinceDomainRequest request
    )
    {
      return RegisterProvinceHelper.Execute(request);
    }

    public Result<UpdateCityDomainResponse> UpdateCity(UpdateCityDomainRequest request)
    {
      return UpdateCityHelper.Execute(request);
    }

    public Result<UpdateCountryDomainResponse> UpdateCountry(UpdateCountryDomainRequest request)
    {
      return UpdateCountryHelper.Execute(request);
    }

    public Result<UpdateProvinceDomainResponse> UpdateProvince(UpdateProvinceDomainRequest request)
    {
      return UpdateProvinceHelper.Execute(request);
    }
  }
}
