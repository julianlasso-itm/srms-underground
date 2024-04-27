using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Aggregates.Helpers;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Domain.Aggregate.Base;
using Shared.Domain.Events.Interfaces;

namespace Profiles.Domain.Aggregates;

public class PersonnelAggregateRoot : BaseAggregateRoot, IPersonnelAggregateRoot
{
    private AccountAggregate AccountAggregate { get; init; }

    public PersonnelAggregateRoot(IEvent eventHandler)
        : base(eventHandler)
    {
        AccountAggregate = new AccountAggregate();
    }

    public RegisterCountryDomainResponse RegisterCountry(RegisterCountryDomainRequest request)
    {
        return AccountAggregate.RegisterCountry(request);
    }

    public UpdateCountryDomainResponse UpdateCountry(UpdateCountryDomainRequest request)
    {
        return AccountAggregate.UpdateCountry(request);
    }

    public DeleteCountryDomainResponse DeleteCountry(DeleteCountryDomainRequest request)
    {
        return AccountAggregate.DeleteCountry(request);
    }

    public RegisterProvinceDomainResponse RegisterProvince(RegisterProvinceDomainRequest request)
    {
        return AccountAggregate.RegisterProvince(request);
    }

    public UpdateProvinceDomainResponse UpdateProvince(UpdateProvinceDomainRequest request)
    {
        return AccountAggregate.UpdateProvince(request);
    }

    public DeleteProvinceDomainResponse DeleteProvince(DeleteProvinceDomainRequest request)
    {
        return AccountAggregate.DeleteProvince(request);
    }

    public RegisterCityDomainResponse RegisterCity(RegisterCityDomainRequest request)
    {
        return AccountAggregate.RegisterCity(request);
    }

    public UpdateCityDomainResponse UpdateCity(UpdateCityDomainRequest request)
    {
        return AccountAggregate.UpdateCity(request);
    }

    public DeleteCityDomainResponse DeleteCity(DeleteCityDomainRequest request)
    {
        return AccountAggregate.DeleteCity(request);
    }

    public RegisterRoleDomainResponse RegisterRole(RegisterRoleDomainRequest roleData)
    {
        return RegisterRoleHelper.Execute(roleData);
    }

    public DeleteRoleDomainResponse DeleteRole(DeleteRoleDomainRequest dataDeleteRole)
    {
        return DeleteRoleHelper.Execute(dataDeleteRole);
    }

    public UpdateRoleDomainResponse UpdateRole(UpdateRoleDomainRequest dataUpdateRole)
    {
        return UpdateRoleHelper.Execute(dataUpdateRole);
    }
}
