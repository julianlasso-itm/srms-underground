using Profiles.Application.AntiCorruption.Interfaces;
using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Application.UseCases;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Common;

namespace Profiles.Application
{
  public class Application<
    TCountryEntity,
    TProvinceEntity,
    TCityEntity,
    TRoleEntity,
    TSkillEntity,
    TProfessionalEntity,
    TLevelEntity
  >(
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication,
    ICountryRepository<TCountryEntity> countryRepository,
    IProvinceRepository<TProvinceEntity> provinceRepository,
    ICityRepository<TCityEntity> cityRepository,
    IRoleRepository<TRoleEntity> roleRepository,
    ISkillRepository<TSkillEntity> skillRepository,
    IProfessionalRepository<TProfessionalEntity> professionalRepository,
    ILevelRepository<TLevelEntity> levelRepository
  )
    : BaseApplication<IPersonnelAggregateRoot, IApplicationToDomain, IDomainToApplication>(
      applicationToDomain,
      domainToApplication
    )
    where TCountryEntity : class
    where TProvinceEntity : class
    where TCityEntity : class
    where TRoleEntity : class
    where TSkillEntity : class
    where TProfessionalEntity : class
    where TLevelEntity : class
  {
    private readonly ICountryRepository<TCountryEntity> _countryRepository = countryRepository;
    private readonly IProvinceRepository<TProvinceEntity> _provinceRepository = provinceRepository;
    private readonly ICityRepository<TCityEntity> _cityRepository = cityRepository;
    private readonly IRoleRepository<TRoleEntity> _roleRepository = roleRepository;
    private readonly ISkillRepository<TSkillEntity> _skillRepository = skillRepository;
    private readonly IProfessionalRepository<TProfessionalEntity> _professionalRepository =
      professionalRepository;
    private readonly ILevelRepository<TLevelEntity> _levelRepository = levelRepository;

    public Task<Result<GetCountriesApplicationResponse<TCountryEntity>>> GetCountries(
      GetCountriesCommand request
    )
    {
      var useCase = new GetCountriesUseCase<TCountryEntity>(
        AggregateRoot,
        _countryRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<RegisterCountryApplicationResponse>> RegisterCountry(
      RegisterCountryCommand request
    )
    {
      var useCase = new RegisterCountryUseCase<TCountryEntity>(
        AggregateRoot,
        _countryRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<UpdateCountryApplicationResponse>> UpdateCountry(
      UpdateCountryCommand request
    )
    {
      var useCase = new UpdateCountryUseCase<TCountryEntity>(
        AggregateRoot,
        _countryRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<DeleteCountryApplicationResponse>> DeleteCountry(
      DeleteCountryCommand request
    )
    {
      var useCase = new DeleteCountryUseCase<TCountryEntity>(
        AggregateRoot,
        _countryRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<GetProvincesApplicationResponse<TProvinceEntity>>> GetProvinces(
      GetProvincesCommand request
    )
    {
      var useCase = new GetProvincesUseCase<TProvinceEntity>(
        AggregateRoot,
        _provinceRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<RegisterProvinceApplicationResponse>> RegisterProvince(
      RegisterProvinceCommand request
    )
    {
      var useCase = new RegisterProvinceUseCase<TProvinceEntity>(
        AggregateRoot,
        _provinceRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<UpdateProvinceApplicationResponse>> UpdateProvince(
      UpdateProvinceCommand request
    )
    {
      var useCase = new UpdateProvinceUseCase<TProvinceEntity>(
        AggregateRoot,
        _provinceRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<DeleteProvinceApplicationResponse>> DeleteProvince(
      DeleteProvinceCommand request
    )
    {
      var useCase = new DeleteProvinceUseCase<TProvinceEntity>(
        AggregateRoot,
        _provinceRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<GetCitiesApplicationResponse<TCityEntity>>> GetCities(
      GetCitiesCommand request
    )
    {
      var useCase = new GetCitiesUseCase<TCityEntity>(
        AggregateRoot,
        _cityRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<RegisterCityApplicationResponse>> RegisterCity(RegisterCityCommand request)
    {
      var useCase = new RegisterCityUseCase<TCityEntity>(
        AggregateRoot,
        _cityRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<UpdateCityApplicationResponse>> UpdateCity(UpdateCityCommand request)
    {
      var useCase = new UpdateCityUseCase<TCityEntity>(
        AggregateRoot,
        _cityRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<DeleteCityApplicationResponse>> DeleteCity(DeleteCityCommand request)
    {
      var useCase = new DeleteCityUseCase<TCityEntity>(
        AggregateRoot,
        _cityRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<RegisterRoleApplicationResponse>> RegisterRole(RegisterRoleCommand request)
    {
      var useCase = new RegisterRoleUseCase<TRoleEntity>(
        AggregateRoot,
        _roleRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<UpdateRoleApplicationResponse>> UpdateRole(UpdateRoleCommand request)
    {
      var useCase = new UpdateRoleUseCase<TRoleEntity>(
        AggregateRoot,
        _roleRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<DeleteRoleApplicationResponse>> DeleteRole(DeleteRoleCommand request)
    {
      var useCase = new DeleteRoleUseCase<TRoleEntity>(
        AggregateRoot,
        _roleRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<GetRolesApplicationResponse<TRoleEntity>>> GetRoles(GetRolesCommand request)
    {
      var useCase = new GetRolesUseCase<TRoleEntity>(
        AggregateRoot,
        _roleRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

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

    public Task<Result<RegisterProfessionalApplicationResponse>> RegisterProfessional(
      RegisterProfessionalCommand request
    )
    {
      var useCase = new RegisterProfessionalUseCase<TProfessionalEntity>(
        AggregateRoot,
        _professionalRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<DeleteProfessionalApplicationResponse>> DeleteProfessional(
      DeleteProfessionalCommand request
    )
    {
      var useCase = new DeleteProfessionalUseCase<TProfessionalEntity>(
        AggregateRoot,
        _professionalRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<GetProfessionalsApplicationResponse<TProfessionalEntity>>> GetProfessional(
      GetProfessionalsCommand request
    )
    {
      var useCase = new GetProfessionalsUseCase<TProfessionalEntity>(
        AggregateRoot,
        _professionalRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<UpdateProfessionalApplicationResponse>> UpdateProfessional(
      UpdateProfessionalCommand request
    )
    {
      var useCase = new UpdateProfessionalUseCase<TProfessionalEntity>(
        AggregateRoot,
        _professionalRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<RegisterLevelApplicationResponse>> RegisterLevel(
      RegisterLevelCommand request
    )
    {
      var useCase = new RegisterLevelUseCase<TLevelEntity>(
        AggregateRoot,
        _levelRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<UpdateLevelApplicationResponse>> UpdateLevel(UpdateLevelCommand request)
    {
      var useCase = new UpdateLevelUseCase<TLevelEntity>(
        AggregateRoot,
        _levelRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<Result<DeleteLevelApplicationResponse>> DeleteLevel(DeleteLevelCommand request)
    {
      var useCase = new DeleteLevelUseCase<TLevelEntity>(
        AggregateRoot,
        _levelRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }
  }
}
