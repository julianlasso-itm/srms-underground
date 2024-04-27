using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Interfaces;

public interface IPersonnelAggregateRoot : IAggregateRoot {
    public DeleteRoleDomainResponse DeleteRole(DeleteRoleDomainRequest dataDeleteRole);
    public RegisterRoleDomainResponse RegisterRole(RegisterRoleDomainRequest roleData);
    public UpdateRoleDomainResponse UpdateRole(UpdateRoleDomainRequest dataUpdateRole);
}
