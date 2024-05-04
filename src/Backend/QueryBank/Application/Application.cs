using QueryBank.Application.AntiCorruption.Interfaces;
using QueryBank.Application.Commands;
using QueryBank.Application.Repositories;
using QueryBank.Application.Responses;
using QueryBank.Application.UseCases;
using QueryBank.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace QueryBank.Application
{
  public class Application<TSkillEntity>
    : BaseApplication<ICatalogAggregateRoot, IApplicationToDomain, IDomainToApplication>
    where TSkillEntity : class
  {
    private readonly ISkillRepository<TSkillEntity> _skillRepository;

    public Application(
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication,
      ISkillRepository<TSkillEntity> skillRepository
    )
      : base(applicationToDomain, domainToApplication)
    {
      _skillRepository = skillRepository;
    }

    public Task<RegisterSkillApplicationResponse> RegisterSkill(RegisterSkillCommand request)
    {
      var useCase = new RegisterSkillUseCase<TSkillEntity>(
        AggregateRoot,
        _skillRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<DeleteSkillApplicationResponse> DeleteSkill(DeleteSkillCommand request)
    {
      var useCase = new DeleteSkillUseCase<TSkillEntity>(
        AggregateRoot,
        _skillRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<GetSkillsApplicationResponse<TSkillEntity>> GetSkills(GetSkillsCommand request)
    {
      var useCase = new GetSkillsUseCase<TSkillEntity>(
        AggregateRoot,
        _skillRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<UpdateSkillApplicationResponse> UpdateSkill(UpdateSkillCommand request)
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
