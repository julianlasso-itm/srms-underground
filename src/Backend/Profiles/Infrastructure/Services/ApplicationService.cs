using Profiles.Application;
using Profiles.Application.Repositories;
using Profiles.Domain.Aggregates;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Events;

namespace Profiles.Infrastructure.Services
{
    internal class ApplicationService
    {
        private readonly Application<
            CountryModel,
            ProvinceModel,
            CityModel,
            RoleModel,
            SkillModel,
            ProfessionalModel
        > _application;

        public ApplicationService(
            SharedEventHandler eventHandler,
            ICountryRepository<CountryModel> countryRepository,
            IProvinceRepository<ProvinceModel> provinceRepository,
            ICityRepository<CityModel> cityRepository,
            IRoleRepository<RoleModel> roleRepository,
            ISkillRepository<SkillModel> skillRepository,
            IProfessionalRepository<ProfessionalModel> professionalRepository
        )
        {
            _application = new Application<
                CountryModel,
                ProvinceModel,
                CityModel,
                RoleModel,
                SkillModel,
                ProfessionalModel
            >(
                countryRepository,
                provinceRepository,
                cityRepository,
                roleRepository,
                skillRepository,
                professionalRepository
            )
            {
                AggregateRoot = new PersonnelAggregateRoot(eventHandler)
            };
        }

        public Application<
            CountryModel,
            ProvinceModel,
            CityModel,
            RoleModel,
            SkillModel,
            ProfessionalModel
        > GetApplication()
        {
            return _application;
        }
    }
}
