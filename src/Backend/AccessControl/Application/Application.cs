using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Application.UseCases;
using AccessControl.Domain.Aggregates.Interfaces;

namespace AccessControl.Application;

public class Application<TEntity>
    where TEntity : class
{
    public ISecurityAggregateRoot? AggregateRoot { get; init; }

    private RegisterUserUseCase<TEntity>? _registerUserUseCase;
    private readonly IUserRepository<TEntity>? _userRepository;

    public Application(IUserRepository<TEntity> userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<RegisterUserResponse> RegisterUser(NewUserCommand request)
    {
        ValidateAggregateRoot();
        _registerUserUseCase ??= new RegisterUserUseCase<TEntity>(AggregateRoot!, _userRepository!);
        var response = _registerUserUseCase.Handle(request);
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
