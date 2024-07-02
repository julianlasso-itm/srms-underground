using Analytics.Domain.Aggregates.Dto.Requests;
using Analytics.Domain.Aggregates.Dto.Responses;
using Analytics.Domain.Aggregates.Helpers;
using Analytics.Domain.Aggregates.Interfaces;
using Shared.Common;
using Shared.Domain.Aggregate.Bases;
using Shared.Domain.Events.Interfaces;

namespace Analytics.Domain.Aggregates
{
  public class AggregateRoot(IEvent eventInterface)
    : BaseAggregateRoot(eventInterface),
      IAggregateRoot
  {
    public Result<DeleteLevelDomainResponse> DeleteLevel(DeleteLevelDomainRequest request)
    {
      return DeleteLevelHelper.Execute(request);
    }

    public Result<RegisterLevelDomainResponse> RegisterLevel(RegisterLevelDomainRequest request)
    {
      return RegisterLevelHelper.Execute(request);
    }

    public Result<UpdateLevelDomainResponse> UpdateLevel(UpdateLevelDomainRequest request)
    {
      return UpdateLevelHelper.Execute(request);
    }
  }
}
