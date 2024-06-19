using System.Net;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Dto.Responses;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;
using Shared.Common.Bases;
using ApplicationException = Shared.Application.Exceptions.ApplicationException;

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
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >(aggregateRoot, aclInputMapper, aclOutputMapper)
    where TEntity : class
  {
    private readonly IUserRepository<TEntity> _userRepository = userRepository;

    public override async Task<Result> Handle(VerifyTokenCommand request)
    {
      var token = AclInputMapper.ToVerifyTokenDomainRequest(request);
      var response = AggregateRoot.VerifyToken(token);

      if (response.IsFailure)
      {
        return response;
      }

      if (response is SuccessResult<VerifyTokenDomainResponse> successResponse)
      {
        var data = successResponse.Data;
        var userId = await _userRepository.GetIdByEmail(data.Email);
        return new SuccessResult<VerifyTokenApplicationResponse>(
          AclOutputMapper.ToVerifyTokenApplicationResponse(data, userId, data.Photo)
        );
      }

      throw new ApplicationException(
        "Invalid response into VerifyTokenUseCase for AccessControl application",
        HttpStatusCode.InternalServerError
      );
    }
  }
}
