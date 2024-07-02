using QueryBank.Application.AntiCorruption.Interfaces;
using QueryBank.Application.Commands;
using QueryBank.Application.Repositories;
using QueryBank.Application.Responses;
using QueryBank.Application.UseCases;
using QueryBank.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;

namespace QueryBank.Application
{
  public class Application<TSkillEntity>(
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication,
    ISkillRepository<TSkillEntity> skillRepository
  )
    : BaseApplication<ICatalogAggregateRoot, IApplicationToDomain, IDomainToApplication>(
      applicationToDomain,
      domainToApplication
    )
    where TSkillEntity : class
  {
    private readonly ISkillRepository<TSkillEntity> _skillRepository = skillRepository;

    public Task<Result<RegisterSkillApplicationResponse>> RegisterSkill(
      RegisterSkillCommand request
    )
    {
      var useCase = new RegisterSkillUseCase<TSkillEntity>(
        AggregateRoot,
        _skillRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<DeleteSkillApplicationResponse>> DeleteSkill(DeleteSkillCommand request)
    {
      var useCase = new DeleteSkillUseCase<TSkillEntity>(
        AggregateRoot,
        _skillRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<GetSkillsApplicationResponse<TSkillEntity>>> GetSkills(
      GetSkillsCommand request
    )
    {
      var useCase = new GetSkillsUseCase<TSkillEntity>(
        AggregateRoot,
        _skillRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<UpdateSkillApplicationResponse>> UpdateSkill(UpdateSkillCommand request)
    {
      var useCase = new UpdateSkillUseCase<TSkillEntity>(
        AggregateRoot,
        _skillRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }
  }
}
