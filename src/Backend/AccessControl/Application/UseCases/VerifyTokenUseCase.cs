using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Application.Interfaces;

namespace AccessControl.Application.UseCases
{
  public sealed class VerifyTokenUseCase
    : BaseUseCase<
      VerifyTokenCommand,
      VerifyTokenApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
  {
    public VerifyTokenUseCase(
      ISecurityAggregateRoot aggregateRoot,
      IApplicationToDomain aclInputMapper,
      IDomainToApplication aclOutputMapper
    )
      : base(aggregateRoot, aclInputMapper, aclOutputMapper) { }

    public override Task<VerifyTokenApplicationResponse> Handle(VerifyTokenCommand request)
    {
      var token = AclInputMapper.ToVerifyTokenDomainRequest(request);
      var response = AggregateRoot.VerifyToken(token);
      return Task.FromResult(AclOutputMapper.ToVerifyTokenApplicationResponse(response));
    }
  }
}
