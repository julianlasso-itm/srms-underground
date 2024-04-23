using Analytics.Domain.Aggregates.Dto;

namespace Analytics.Domain.Aggregates.Interfaces;

public interface IAggregateRoot : Shared.Domain.Aggregate.Interfaces.IAggregateRoot
{
    public RegisterLevelResponse RegisterLevel(RegisterLevel request);
    public UpdateLevelResponse UpdateLevel(UpdateLevel request);
}
