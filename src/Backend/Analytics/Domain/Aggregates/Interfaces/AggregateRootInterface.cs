using Analytics.Domain.Aggregates.Dto.Requests;
using Analytics.Domain.Aggregates.Dto.Responses;
using Shared.Common;

namespace Analytics.Domain.Aggregates.Interfaces
{
  public interface IAggregateRoot : Shared.Domain.Aggregate.Interfaces.IAggregateRoot
  {
    public Result<RegisterLevelDomainResponse> RegisterLevel(RegisterLevelDomainRequest request);
    public Result<UpdateLevelDomainResponse> UpdateLevel(UpdateLevelDomainRequest request);
    public Result<DeleteLevelDomainResponse> DeleteLevel(DeleteLevelDomainRequest request);
  }
}
