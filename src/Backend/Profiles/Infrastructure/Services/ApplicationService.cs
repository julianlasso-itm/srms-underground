using Profiles.Application;
using Profiles.Application.Repositories;
using Profiles.Domain.Aggregates;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Events;

namespace Profiles.Infrastructure.Services
{
    public class ApplicationService
    {
        private readonly Application<Skill, Professional> _application;

        public ApplicationService(
            SharedEventHandler eventHandler,
            ISkillRepository<Skill> skillRepository,
            IProfessionalRepository<Professional> professionalRepository
        )
        {
            _application = new Application<Skill, Professional>(
                skillRepository,
                professionalRepository
            )
            {
                AggregateRoot = new PersonnelAggregateRoot(eventHandler)
            };
        }

        public Application<Skill, Professional> GetApplication()
        {
            return _application;
        }
    }
}
