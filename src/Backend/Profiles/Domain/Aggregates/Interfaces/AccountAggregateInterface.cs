using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Shared.Common;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Interfaces
{
  public interface IAccountAggregate : IAggregate
  {
    public Result<RegisterCountryDomainResponse> RegisterCountry(
      RegisterCountryDomainRequest request
    );
    public Result<UpdateCountryDomainResponse> UpdateCountry(UpdateCountryDomainRequest request);
    public Result<DeleteCountryDomainResponse> DeleteCountry(DeleteCountryDomainRequest request);
    public Result<RegisterProvinceDomainResponse> RegisterProvince(
      RegisterProvinceDomainRequest request
    );
    public Result<UpdateProvinceDomainResponse> UpdateProvince(UpdateProvinceDomainRequest request);
    public Result<DeleteProvinceDomainResponse> DeleteProvince(DeleteProvinceDomainRequest request);
    public Result<RegisterCityDomainResponse> RegisterCity(RegisterCityDomainRequest request);
    public Result<UpdateCityDomainResponse> UpdateCity(UpdateCityDomainRequest request);
    public Result<DeleteCityDomainResponse> DeleteCity(DeleteCityDomainRequest request);
  }
}
