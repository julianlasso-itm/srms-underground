using Profiles.Application;
using Profiles.Application.Repositories;
using Profiles.Domain.Aggregates;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Events;

namespace Profiles.Infrastructure.Services
{
    public class ApplicationService
    {
        private readonly Application<SkillModel, ProfessionalModel> _application;

        public ApplicationService(
            SharedEventHandler eventHandler,
            ISkillRepository<SkillModel> skillRepository,
            IProfessionalRepository<ProfessionalModel> professionalRepository
        )
        {
            _application = new Application<SkillModel, ProfessionalModel>(
                skillRepository,
                professionalRepository
            )
            {
                AggregateRoot = new PersonnelAggregateRoot(eventHandler)
            };
        }

        public Application<SkillModel, ProfessionalModel> GetApplication()
        {
            return _application;
        }
    }
}
