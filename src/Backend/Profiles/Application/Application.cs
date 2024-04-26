using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Application.UseCases;
using Profiles.Domain.Aggregates.Interfaces;
using Profiles.Domain.Entities;
using Profiles.Infrastructure.Services.helpers;

namespace Profiles.Application;

public class Application<TCountryEntity, TProvinceEntity, TCityEntity, TSkillEntity>
    where TCountryEntity : class
    where TProvinceEntity : class
    where TCityEntity : class
    where TSkillEntity : class
{
    public required IPersonnelAggregateRoot AggregateRoot { get; init; }

    private readonly ICountryRepository<TCountryEntity> _countryRepository;
    private readonly IProvinceRepository<TProvinceEntity> _provinceRepository;
    private readonly ICityRepository<TCityEntity> _cityRepository;
    private readonly ISkillRepository<TSkillEntity> _skillRepository;

    public Application(
        ICountryRepository<TCountryEntity> countryRepository,
        IProvinceRepository<TProvinceEntity> provinceRepository,
        ICityRepository<TCityEntity> cityRepository,
        ISkillRepository<TSkillEntity> skillRepository
    )
    {
        _skillRepository = skillRepository;
        _countryRepository = countryRepository;
        _provinceRepository = provinceRepository;
        _cityRepository = cityRepository;
    }

    public Application(ISkillRepository<TSkillEntity> skillRepository)
    {
        _skillRepository = skillRepository;
    }


    public Task<RegisterCountryApplicationResponse> RegisterCountry(RegisterCountryCommand request)
    {
        var useCase = new RegisterCountryUseCase<TCountryEntity>(AggregateRoot, _countryRepository);
        return useCase.Handle(request);
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
}
