using QueryBank.Application;
using QueryBank.Application.Repositories;
using QueryBank.Domain.Aggregates;
using QueryBank.Infrastructure.Messaging.Events;
using QueryBank.Infrastructure.Persistence.Models;

namespace QueryBank.Infrastructure.Services
{
    public class ApplicationService
    {
        private readonly Application<Question> _application;

        public ApplicationService(RegisterQuestionlEvent registerQuestionEvent,
        IQuestionRepository<Question> questionRepository)
        {
            _application = new Application<Question>(questionRepository)
            {
                AggregateRoot = new CatalogAggregateRoot(registerQuestionEvent)
            };
        }

        public Application<Question> GetApplication()
        {
            return _application;
        }
    }
}
