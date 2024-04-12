using AccessControl.Domain.Aggregates.Dto;
using Shared.Domain.Aggregate.Interfaces;

namespace AccessControl.Domain.Aggregates.Interfaces;

public interface ISecurityAggregateRoot : IAggregate
{
    public RegisterCredentialResponse RegisterCredential(RegisterCredential registerData);
}
