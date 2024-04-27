using QueryBank.Application;
using QueryBank.Application.Repositories;
using QueryBank.Domain.Aggregates;
using QueryBank.Infrastructure.Persistence.Models;
using QueryBank.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Events;

namespace QueryBank.Infrastructure.Services;

public class ApplicationService
{
    private readonly IEnumerable<Question> _application;

    public ApplicationService(
        SharedEventHandler eventHandler,
        IQuestionRepository<Question> roleRepository
    )
    {
        throw new NotImplementedException();
        // _application = new Application<Question>(roleRepository)
        // {
        //     AggregateRoot = new CatalogAggregateRoot(eventHandler)
        // };
    }

    public IEnumerable<Question> GetApplication()
    {
        throw new NotImplementedException();
        // return _application;
    }
}
