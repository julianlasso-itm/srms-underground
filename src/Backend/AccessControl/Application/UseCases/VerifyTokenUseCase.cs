using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases
{
  public sealed class VerifyTokenUseCase<TEntity>
    : BaseUseCase<
      VerifyTokenCommand,
      VerifyTokenApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TEntity : class
  {
    private readonly IUserRepository<TEntity> _userRepository;

    public VerifyTokenUseCase(
      IUserRepository<TEntity> userRepository,
      ISecurityAggregateRoot aggregateRoot,
      IApplicationToDomain aclInputMapper,
      IDomainToApplication aclOutputMapper
    )
      : base(aggregateRoot, aclInputMapper, aclOutputMapper)
    {
      _userRepository = userRepository;
    }

    public override async Task<VerifyTokenApplicationResponse> Handle(VerifyTokenCommand request)
    {
    var token = AclInputMapper.ToVerifyTokenDomainRequest(request);
      var response = AggregateRoot.VerifyToken(token);
      var userId = await _userRepository.GetIdByEmail(response.Email);
      return AclOutputMapper.ToVerifyTokenApplicationResponse(response, userId, response.Photo);
    }
  }
}
