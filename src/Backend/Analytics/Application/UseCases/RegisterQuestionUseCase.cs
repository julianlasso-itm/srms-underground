using System.Text.Json;
using Analytics.Application.Commands;
using Analytics.Application.Repositories;
using Analytics.Application.Responses;
using Analytics.Domain.Aggregates.Constants;
using Analytics.Domain.Aggregates.Dto.Requests;
using Analytics.Domain.Aggregates.Dto.Responses;
using Analytics.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Analytics.Application.UseCases;

public sealed class RegisterQuestionUseCase<TEntity>
    : BaseUseCase<RegisterQuestionCommand, RegisterQuestionApplicationResponse, IAggregateRoot>
    where TEntity : class
{
    private readonly IQuestionRepository<TEntity> _roleRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventQuestionRegistered}";

    public RegisterQuestionUseCase(
        ISecurityAggregateRoot aggregateRoot,
        IQuestionRepository<TEntity> roleRepository
    )
        : base(aggregateRoot)
    {
        _roleRepository = roleRepository;
    }

    public override async Task<RegisterQuestionApplicationResponse> Handle(RegisterQuestionCommand request)
    {
        var newQuestion = MapToRequestForDomain(request);
        var role = AggregateRoot.RegisterQuestion(newQuestion);
        var response = MapToResponse(role);
        _ = await Persistence(response);
        EmitEvent(Channel, JsonSerializer.Serialize(response));
        return response;
    }

    private RegisterQuestionDomainRequest MapToRequestForDomain(RegisterQuestionCommand request)
    {
        return new RegisterQuestionDomainRequest
        {
            Name = request.Name,
            Description = request.Description,
        };
    }

    private RegisterQuestionApplicationResponse MapToResponse(RegisterQuestionDomainResponse role)
    {
        return new RegisterQuestionApplicationResponse
        {
            QuestionId = role.QuestionId,
            Name = role.Name,
            Description = role.Description,
            Disabled = role.Disabled,
        };
    }

    private async Task<TEntity> Persistence(RegisterQuestionApplicationResponse response)
    {
        return await _roleRepository.AddAsync(response);
    }
}
