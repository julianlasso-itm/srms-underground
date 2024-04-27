using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Application.UseCases;
using Profiles.Domain.Aggregates.Interfaces;
using Profiles.Domain.Entities;
using Profiles.Infrastructure.Services.helpers;

namespace Profiles.Application;

public class Application<TCountryEntity, TProvinceEntity, TCityEntity, TSkillEntity, TProfessionalEntity, TRoleEntity>
    where TCountryEntity : class
    where TProvinceEntity : class
    where TCityEntity : class
    where TSkillEntity : class
    where TProfessionalEntity : class
    where TRoleEntity : class
{
    public required IPersonnelAggregateRoot AggregateRoot { get; init; }

    private readonly ICountryRepository<TCountryEntity> _countryRepository;
    private readonly IProvinceRepository<TProvinceEntity> _provinceRepository;
    private readonly ICityRepository<TCityEntity> _cityRepository;
    private readonly ISkillRepository<TSkillEntity> _skillRepository;
    private readonly IProfessionalRepository<TProfessionalEntity> _professionalRepository;
    private readonly IRoleRepository<TRoleEntity> _roleRepository;

    public Application(
        ICountryRepository<TCountryEntity> countryRepository,
        IProvinceRepository<TProvinceEntity> provinceRepository,
        ICityRepository<TCityEntity> cityRepository,
        ISkillRepository<TSkillEntity> skillRepository,
        IProfessionalRepository<TProfessionalEntity> professionalRepository
        IRoleRepository<TRoleEntity> roleRepository
    )
    {
        _skillRepository = skillRepository;
        _countryRepository = countryRepository;
        _provinceRepository = provinceRepository;
        _cityRepository = cityRepository;
        _professionalRepository = professionalRepository;
        _roleRepository = roleRepository;
    }

    public Application(ISkillRepository<TSkillEntity> skillRepository, IProfessionalRepository<TProfessionalEntity> professionalRepository, IRoleRepository<TRoleEntity> roleRepository)
    {
        _skillRepository = skillRepository;
        _professionalRepository = professionalRepository;
        _roleRepository = roleRepository;
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

    public Task<RegisterProfessionalApplicationResponse> RegisterProfessional(RegisterProfessionalCommand request)
    {
        var useCase = new RegisterProfessionalUseCase<TProfessionalEntity>(AggregateRoot, _professionalRepository);
        return useCase.Handle(request);
    }

    public Task<DeleteProfessionalApplicationResponse> DeleteProfessional(DeleteProfessionalCommand request)
    {
        var useCase = new DeleteProfessionalUseCase<TProfessionalEntity>(AggregateRoot, _professionalRepository);
        return useCase.Handle(request);
    }

    public Task<GetProfessionalsApplicationResponse<TProfessionalEntity>> GetProfessional(GetProfessionalsCommand request)
    {
        var useCase = new GetProfessionalsUseCase<TProfessionalEntity>(AggregateRoot, _professionalRepository);
        return useCase.Handle(request);
    }

    public Task<UpdateProfessionalApplicationResponse> UpdateProfessional(UpdateProfessionalCommand request)
    {
        var useCase = new UpdateProfessionalUseCase<TProfessionalEntity>(AggregateRoot, _professionalRepository);
        return useCase.Handle(request);
    }

    public Task<RegisterRoleApplicationResponse> RegisterRole(RegisterRoleCommand request)
    {
        var useCase = new RegisterRoleUseCase<TRoleEntity>(AggregateRoot, _roleRepository);
        return useCase.Handle(request);
    }

    public Task<UpdateRoleApplicationResponse> UpdateRole(UpdateRoleCommand request)
    {
        var useCase = new UpdateRoleUseCase<TRoleEntity>(AggregateRoot, _roleRepository);
        return useCase.Handle(request);
    }

    public Task<DeleteRoleApplicationResponse> DeleteRole(DeleteRoleCommand request)
    {
        var useCase = new DeleteRoleUseCase<TRoleEntity>(AggregateRoot, _roleRepository);
        return useCase.Handle(request);
    }

    public Task<GetRolesApplicationResponse<TRoleEntity>> GetRoles(GetRolesCommand request)
    {
        var useCase = new GetRolesUseCase<TRoleEntity>(AggregateRoot, _roleRepository);
        return useCase.Handle(request);
    }
}
