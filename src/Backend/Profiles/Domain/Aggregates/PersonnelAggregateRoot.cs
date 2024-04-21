using Profiles.Domain.Aggregates.Interfaces;
using Shared.Domain.Aggregate.Base;
using Shared.Domain.Events.Interfaces;

namespace Profiles.Domain.Aggregates;

public class PersonnelAggregateRoot : BaseAggregateRoot, IPersonnelAggregateRoot
{
    public IAccountAggregate AccountAggregate { get; init; }

    public PersonnelAggregateRoot(IEvent eventInterface)
        : base(eventInterface) { }
}
