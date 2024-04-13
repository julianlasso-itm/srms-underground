using Analytics.Domain.Aggregates.Dto;
using Shared.Domain.Aggregate.Interfaces;

namespace Analytics.Domain.Aggregates.Interfaces;

public interface IAggregateRoot : IAggregate
{
    public RegisterLevelResponse RegisterLevel(RegisterLevel request);
    public UpdateLevelResponse UpdateLevel(UpdateLevel request);
}
