using Profiles.Application;
using Profiles.Application.Repositories;
using Profiles.Domain.Aggregates;
using Profiles.Infrastructure.Messaging.Events;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Services
{
    public class ApplicationService
    {
        private readonly Application<Country, State, City, Skill, Professional> _application;

        public ApplicationService(RegisterSkillEvent registerSkillEvent,
        ISkillRepository<Skill> skillRepository, IProfessionalRepository<Professional> professionalRepository)
        {
            _application = new Application<Country, State, City, Skill, Professional>(skillRepository, professionalRepository)
            {
                AggregateRoot = new PersonnelAggregateRoot(registerSkillEvent)
            };
        }

        public Application<Country, State, City, Skill, Professional> GetApplication()
        {
            return _application;
        }
    }
}
