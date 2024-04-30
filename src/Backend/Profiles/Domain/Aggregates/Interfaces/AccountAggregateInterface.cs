using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Interfaces
{
  public interface IAccountAggregate : IAggregate
  {
    public RegisterCountryDomainResponse RegisterCountry(RegisterCountryDomainRequest request);
    public UpdateCountryDomainResponse UpdateCountry(UpdateCountryDomainRequest request);
    public DeleteCountryDomainResponse DeleteCountry(DeleteCountryDomainRequest request);
    public RegisterProvinceDomainResponse RegisterProvince(RegisterProvinceDomainRequest request);
    public UpdateProvinceDomainResponse UpdateProvince(UpdateProvinceDomainRequest request);
    public DeleteProvinceDomainResponse DeleteProvince(DeleteProvinceDomainRequest request);
    public RegisterCityDomainResponse RegisterCity(RegisterCityDomainRequest request);
    public UpdateCityDomainResponse UpdateCity(UpdateCityDomainRequest request);
    public DeleteCityDomainResponse DeleteCity(DeleteCityDomainRequest request);
  }
}
