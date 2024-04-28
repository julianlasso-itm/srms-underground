using Analytics.Domain.Aggregates.Dto.Requests;
using Analytics.Domain.Aggregates.Dto.Responses;

namespace Analytics.Domain.Aggregates.Interfaces;

public interface IAggregateRoot : Shared.Domain.Aggregate.Interfaces.IAggregateRoot
{
    public RegisterLevelDomainResponse RegisterLevel(RegisterLevelDomainRequest request);
    public UpdateLevelDomainResponse UpdateLevel(UpdateLevelDomainRequest request);
    public DeleteLevelDomainResponse DeleteLevel(DeleteLevelDomainRequest request);
}
