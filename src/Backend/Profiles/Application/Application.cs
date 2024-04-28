using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Application.UseCases;
using Profiles.Domain.Aggregates.Interfaces;
using Profiles.Infrastructure.Services.helpers;

namespace Profiles.Application;

public class Application<TSkillEntity, TProfessionalEntity>
    where TSkillEntity : class
    where TProfessionalEntity : class
{
    public required IPersonnelAggregateRoot AggregateRoot { get; init; }
    private readonly ISkillRepository<TSkillEntity> _skillRepository;
    private readonly IProfessionalRepository<TProfessionalEntity> _professionalRepository;

    public Application(
        ISkillRepository<TSkillEntity> skillRepository,
        IProfessionalRepository<TProfessionalEntity> professionalRepository
    )
    {
        _skillRepository = skillRepository;
        _professionalRepository = professionalRepository;
    }

    public Task<RegisterSkillApplicationResponse> RegisterSkill(RegisterSkillCommand request)
    {
        var useCase = new RegisterSkillUseCase<TSkillEntity>(AggregateRoot, _skillRepository);
        return useCase.Handle(request);
    }

    public Task<DeleteSkillApplicationResponse> DeleteSkill(DeleteSkillCommand request)
    {
        var useCase = new DeleteSkillUseCase<TSkillEntity>(AggregateRoot, _skillRepository);
        return useCase.Handle(request);
    }

    public Task<GetSkillsApplicationResponse<TSkillEntity>> GetSkills(GetSkillsCommand request)
    {
        var useCase = new GetSkillsUseCase<TSkillEntity>(AggregateRoot, _skillRepository);
        return useCase.Handle(request);
    }

    public Task<UpdateSkillApplicationResponse> UpdateSkill(UpdateSkillCommand request)
    {
        var useCase = new UpdateSkillUseCase<TSkillEntity>(AggregateRoot, _skillRepository);
        return useCase.Handle(request);
    }

    public Task<RegisterProfessionalApplicationResponse> RegisterProfessional(
        RegisterProfessionalCommand request
    )
    {
        var useCase = new RegisterProfessionalUseCase<TProfessionalEntity>(
            AggregateRoot,
            _professionalRepository
        );
        return useCase.Handle(request);
    }

    public Task<DeleteProfessionalApplicationResponse> DeleteProfessional(
        DeleteProfessionalCommand request
    )
    {
        var useCase = new DeleteProfessionalUseCase<TProfessionalEntity>(
            AggregateRoot,
            _professionalRepository
        );
        return useCase.Handle(request);
    }

    public Task<GetProfessionalsApplicationResponse<TProfessionalEntity>> GetProfessional(
        GetProfessionalsCommand request
    )
    {
        var useCase = new GetProfessionalsUseCase<TProfessionalEntity>(
            AggregateRoot,
            _professionalRepository
        );
        return useCase.Handle(request);
    }

    public Task<UpdateProfessionalApplicationResponse> UpdateProfessional(
        UpdateProfessionalCommand request
    )
    {
        var useCase = new UpdateProfessionalUseCase<TProfessionalEntity>(
            AggregateRoot,
            _professionalRepository
        );
        return useCase.Handle(request);
    }
}
