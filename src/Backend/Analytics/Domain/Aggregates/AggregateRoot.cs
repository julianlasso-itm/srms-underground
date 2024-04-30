using Analytics.Domain.Aggregates.Dto.Requests;
using Analytics.Domain.Aggregates.Dto.Responses;
using Analytics.Domain.Aggregates.Helpers;
using Analytics.Domain.Aggregates.Interfaces;
using Shared.Domain.Aggregate.Base;
using Shared.Domain.Events.Interfaces;

namespace Analytics.Domain.Aggregates
{
  public class AggregateRoot : BaseAggregateRoot, IAggregateRoot
  {
    public AggregateRoot(IEvent eventInterface)
      : base(eventInterface) { }

    public DeleteLevelDomainResponse DeleteLevel(DeleteLevelDomainRequest request)
    {
      return DeleteLevelHelper.Execute(request);
    }

    public RegisterLevelDomainResponse RegisterLevel(RegisterLevelDomainRequest request)
    {
      return RegisterLevelHelper.Execute(request);
    }

    public UpdateLevelDomainResponse UpdateLevel(UpdateLevelDomainRequest request)
    {
      return UpdateLevelHelper.Execute(request);
    }
  }
}
