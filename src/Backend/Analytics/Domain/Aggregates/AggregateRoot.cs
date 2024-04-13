using Analytics.Domain.Aggregates.Dto;
using Analytics.Domain.Aggregates.Interfaces;
using Shared.Domain.Aggregate.Base;
using Shared.Domain.Events.Interfaces;

namespace Analytics.Domain.Aggregates;

public class AggregateRoot : BaseAggregate, IAggregateRoot
{
    public AggregateRoot(IEvent eventInterface)
        : base(eventInterface) { }

    public RegisterLevelResponse RegisterLevel(RegisterLevel request)
    {
        throw new NotImplementedException();
    }

    public UpdateLevelResponse UpdateLevel(UpdateLevel request)
    {
        throw new NotImplementedException();
    }
}
