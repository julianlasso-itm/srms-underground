using Analytics.Domain.Aggregates.Dto;
using Analytics.Domain.Aggregates.Helpers;
using Analytics.Domain.Aggregates.Interfaces;
using Shared.Domain.Aggregate.Base;
using Shared.Domain.Events.Interfaces;

namespace Analytics.Domain.Aggregates;

public class AggregateRoot : BaseAggregateRoot, IAggregateRoot
{
    public AggregateRoot(IEvent eventInterface)
        : base(eventInterface) { }

    public RegisterLevelResponse RegisterLevel(RegisterLevel request)
    {
        return RegisterLevelHelper.Execute(request);
    }

    public UpdateLevelResponse UpdateLevel(UpdateLevel request)
    {
        return UpdateLevelHelper.Execute(request);
    }
}
