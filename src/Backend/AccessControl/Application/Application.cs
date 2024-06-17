using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Interfaces;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Application.UseCases;
using AccessControl.Domain.Aggregates.Interfaces;
using Application.UseCases;
using Shared.Application.Base;
using Shared.Application.Interfaces;

namespace AccessControl.Application
{
  public class Application<TUserEntity, TRoleEntity>(
    IApplicationToDomain applicationToDomain,
    IDomainToApplication domainToApplication,
    IMessageService messageService,
    ICacheService cacheService,
    IStoreService storeService,
    IUserRepository<TUserEntity> userRepository,
    IRoleRepository<TRoleEntity> roleRepository
  )
    : BaseApplication<ISecurityAggregateRoot, IApplicationToDomain, IDomainToApplication>(
      applicationToDomain,
      domainToApplication
    ),
      IApplication<TUserEntity, TRoleEntity>
    where TUserEntity : class
    where TRoleEntity : class
  {
    private readonly IMessageService _messageService = messageService;
    private readonly ICacheService _cacheService = cacheService;
    private readonly IStoreService _storeService = storeService;
    private readonly IUserRepository<TUserEntity> _userRepository = userRepository;
    private readonly IRoleRepository<TRoleEntity> _roleRepository = roleRepository;

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

    public Task<ChangePasswordApplicationResponse> ChangePassword(ChangePasswordCommand request)
    {
      var useCase = new ChangePasswordUseCase<TUserEntity>(
        _userRepository,
        AggregateRoot,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<PasswordRecoveryApplicationResponse> PasswordRecovery(
      PasswordRecoveryCommand request
    )
    {
      var useCase = new PasswordRecoveryUseCase<TUserEntity>(
        _userRepository,
        _cacheService,
        _messageService,
        AggregateRoot,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<UpdateUserApplicationResponse> UpdateUser(UpdateUserCommand request)
    {
      var useCase = new UpdateUserUseCase<TUserEntity>(
        _userRepository,
        _cacheService,
        _storeService,
        AggregateRoot,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }

    public Task<ResetPasswordApplicationResponse> ResetPassword(ResetPasswordCommand request)
    {
      var useCase = new ResetPasswordUseCase<TUserEntity>(
        _cacheService,
        _userRepository,
        AggregateRoot,
        ApplicationToDomain,
        DomainToApplication
      );
      return useCase.Handle(request);
    }
  }
}
