using Profiles.Application;
using Profiles.Application.Repositories;
using Profiles.Domain.Aggregates;
using Profiles.Infrastructure.Messaging.Events;
using Profiles.Infrastructure.Persistence.Models;

namespace Profiles.Infrastructure.Services
{
    public class ApplicationService
    {
        private readonly Application<Country, State, City, Skill> _application;

        public ApplicationService(RegisterSkillEvent registerSkillEvent,
        ISkillRepository<Skill> skillRepository)
        {
            _application = new Application<Country, State, City, Skill>(skillRepository)
            {
                AggregateRoot = new PersonnelAggregateRoot(registerSkillEvent)
            };
        }

        public Application<Country, State, City, Skill> GetApplication()
        {
            return _application;
        }
    }
}
