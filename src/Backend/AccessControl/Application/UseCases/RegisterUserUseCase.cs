using System.Text.Json;
using AccessControl.Application.AntiCorruption.Interfaces;
using AccessControl.Application.Commands;
using AccessControl.Application.Interfaces;
using AccessControl.Application.Repositories;
using AccessControl.Application.Responses;
using AccessControl.Domain.Aggregates.Constants;
using AccessControl.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace AccessControl.Application.UseCases
{
  public sealed class RegisterUserUseCase<TEntity>
    : BaseUseCase<
      RegisterUserCommand,
      RegisterUserApplicationResponse,
      ISecurityAggregateRoot,
      IApplicationToDomain,
      IDomainToApplication
    >
    where TEntity : class
  {
    private readonly IUserRepository<TEntity> _userRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventCredentialRegistered}";

    public RegisterUserUseCase(
      ISecurityAggregateRoot aggregateRoot,
      IUserRepository<TEntity> userRepository,
      IApplicationToDomain applicationToDomain,
      IDomainToApplication domainToApplication,
      IMessageService messageService
    )
      : base(
        aggregateRoot,
        applicationToDomain,
        domainToApplication,
        new Dictionary<string, object> { { "MessageService", messageService } }
      )
    {
      _userRepository = userRepository;
    }

    public override async Task<RegisterUserApplicationResponse> Handle(RegisterUserCommand request)
    {
      var command = AclInputMapper.ToRegisterCredentialDomainRequest(request);
      var user = AggregateRoot.RegisterCredential(command);
      var response = AclOutputMapper.ToRegisterUserApplicationResponse(user);

      _ = await Persist(response);
      EmitEvent(Channel, JsonSerializer.Serialize(response));
      SendConfirmationEmail(response);

      return response;
    }

    private async Task<TEntity> Persist(RegisterUserApplicationResponse response)
    {
      return await _userRepository.AddAsync(response);
    }

    private void SendConfirmationEmail(RegisterUserApplicationResponse response)
    {
      if (Parameters == null || !Parameters.ContainsKey("MessageService"))
      {
        throw new InvalidOperationException("MessageService parameter is not set.");
      }

      Parameters.TryGetValue("MessageService", out var messageServiceObj);
      var messageService =
        messageServiceObj as IMessageService
        ?? throw new InvalidCastException(
          "Provided messageService object is not of type IMessageService."
        );

      // TODO: Implement token generation
      var token = string.Empty;

      // TODO: Persist token in database
      // await _tokenRepository.AddAsync(token);

      messageService.SendConfirmationEmail(response.UserId, response.Email, token);
    }
  }
}
