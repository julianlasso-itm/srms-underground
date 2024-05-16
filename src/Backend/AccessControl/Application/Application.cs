using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Interfaces;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Application.UseCases;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;
using Shared.Application.Interfaces;

namespace AccessControl.Application
{
  public class Application<TUserEntity, TRoleEntity>
    : BaseApplication<ISecurityAggregateRoot, IApplicationToDomain, IDomainToApplication>,
      IApplication<TUserEntity, TRoleEntity>
    where TUserEntity : class
    where TRoleEntity : class
  {
    private readonly IMessageService _messageService;
    private readonly ICacheService _cacheService;
    private readonly IStoreService _storeService;
    private readonly IUserRepository<TUserEntity> _userRepository;
    private readonly IRoleRepository<TRoleEntity> _roleRepository;

    public Application(
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication,
      IMessageService messageService,
      ICacheService cacheService,
      IStoreService storeService,
      IUserRepository<TUserEntity> userRepository,
      IRoleRepository<TRoleEntity> roleRepository
    )
      : base(applicationToDomain, domainToApplication)
    {
      _messageService = messageService;
      _cacheService = cacheService;
      _storeService = storeService;
      _userRepository = userRepository;
      _roleRepository = roleRepository;
    }

    public Task<RegisterUserApplicationResponse> RegisterUser(RegisterUserCommand request)
    {
      var useCase = new RegisterUserUseCase<TUserEntity>(
        AggregateRoot,
        _userRepository,
        ApplicationToDomain,
        DomainToApplication,
        _messageService,
        _cacheService,
        _storeService
      );
      return useCase.Handle(request);
    }

    public Task<RegisterRoleApplicationResponse> RegisterRole(RegisterRoleCommand request)
    {
      var useCase = new RegisterRoleUseCase<TRoleEntity>(
        AggregateRoot,
        _roleRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<UpdateRoleApplicationResponse> UpdateRole(UpdateRoleCommand request)
    {
      var useCase = new UpdateRoleUseCase<TRoleEntity>(
        AggregateRoot,
        _roleRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<DeleteRoleApplicationResponse> DeleteRole(DeleteRoleCommand request)
    {
      var useCase = new DeleteRoleUseCase<TRoleEntity>(
        AggregateRoot,
        _roleRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<GetRolesApplicationResponse<TRoleEntity>> GetRoles(GetRolesCommand request)
    {
      var useCase = new GetRolesUseCase<TRoleEntity>(
        AggregateRoot,
        _roleRepository,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<ActivationTokenApplicationResponse> ActivateToken(ActivateTokenCommand request)
    {
      var useCase = new ActivateTokenUseCase<TUserEntity>(
        _userRepository,
        _cacheService,
        AggregateRoot,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<SignInApplicationResponse> SignIn(SignInCommand request)
    {
      var useCase = new SignInUseCase<TUserEntity>(
        _userRepository,
        _cacheService,
        AggregateRoot,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<VerifyTokenApplicationResponse> VerifyToken(VerifyTokenCommand request)
    {
      var useCase = new VerifyTokenUseCase<TUserEntity>(
        _userRepository,
        AggregateRoot,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }
  }
}
