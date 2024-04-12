using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Application.UseCases;
using AccessControl.Domain.Aggregates.Interfaces;

namespace AccessControl.Application;

public class Application<TEntity>
    where TEntity : class
{
    public required ISecurityAggregateRoot AggregateRoot { get; init; }

    private readonly IUserRepository<TEntity>? _userRepository;

    public Application(IUserRepository<TEntity> userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<RegisterUserResponse> RegisterUser(NewUserCommand request)
    {
        ValidateAggregateRoot();
        var useCase = new RegisterUserUseCase<TEntity>(AggregateRoot, _userRepository!);
        var response = useCase.Handle(request);
        return response;
    }

    private void ValidateAggregateRoot()
    {
        if (AggregateRoot == null)
        {
            throw new InvalidOperationException("AggregateRoot is not set.");
        }
    }
}
