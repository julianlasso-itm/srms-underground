using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;

namespace AccessControl.Application.UseCases
{
  public sealed class VerifyTokenUseCase<TEntity>(
    IUserRepository<TEntity> userRepository,
    ISecurityAggregateRoot aggregateRoot,
    IApplicationToDomain aclInputMapper,
    IDomainToApplication aclOutputMapper
  )
    : BaseUseCase<
      VerifyTokenCommand,
      VerifyTokenApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, aclInputMapper, aclOutputMapper)
    where TEntity : class
  {
    private readonly IUserRepository<TEntity> _userRepository = userRepository;

    public override async Task<Result<VerifyTokenApplicationResponse>> Handle(
      VerifyTokenCommand request
    )
    {
      var token = AclInputMapper.ToVerifyTokenDomainRequest(request);
      var response = AggregateRoot.VerifyToken(token);

      if (response.IsFailure)
      {
        return Response<VerifyTokenApplicationResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      var data = response.Data;
      var userId = await _userRepository.GetIdByEmail(data.Email);
      return Response<VerifyTokenApplicationResponse>.Success(
        AclOutputMapper.ToVerifyTokenApplicationResponse(data, userId, data.Photo)
      );
    }
  }
}
