using AccessControl.Application.Commands;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Application.UseCases;
using AccessControl.Domain.Aggregates.Interfaces;

namespace AccessControl.Application;

public class Application<TUserEntity, TRoleEntity>
    where TUserEntity : class
    where TRoleEntity : class
{
    public required ISecurityAggregateRoot AggregateRoot { get; init; }

    private readonly RegisterUserUseCase<TEntity> _registerUserUseCase;
    private readonly IUserRepository<TEntity> _userRepository;

    public Application(
        IUserRepository<TUserEntity> userRepository,
        IRoleRepository<TRoleEntity> roleRepository
    )
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public Task<RegisterUserResponse> RegisterUser(NewUserCommand request)
    {
        ValidateAggregateRoot();
        var useCase = new RegisterUserUseCase<TEntity>(AggregateRoot, _userRepository);
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
