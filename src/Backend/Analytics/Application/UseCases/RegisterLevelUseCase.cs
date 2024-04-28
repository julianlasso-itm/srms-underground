﻿using System.Text.Json;
using Analytics.Application.Commands;
using Analytics.Application.Repositories;
using Analytics.Application.Responses;
using Analytics.Domain.Aggregates.Constants;
using Analytics.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Analytics.Application.UseCases;

public sealed class RegisterLevelUseCase<TEntity>
    : BaseUseCase<RegisterLevelCommand, RegisterLevelApplicationResponse, IAggregateRoot>
    where TEntity : class
{
    private readonly ILevelRepository<TEntity> _levelRepository;
    private const string Channel = $"{EventsConst.Prefix}.{EventsConst.EventLevelRegistered}";

    public RegisterLevelUseCase(
        IAggregateRoot aggregateRoot,
        ILevelRepository<TEntity> levelRepository
    )
        : base(aggregateRoot)
    {
        _levelRepository = levelRepository;
    }

    public override async Task<RegisterLevelApplicationResponse> Handle(RegisterLevelCommand request)
    {
        throw new NotImplementedException();
        // var newLevel = MapToRequestForDomain(request);
        // var level = AggregateRoot.RegisterLevel(newLevel);
        // var response = MapToResponse(level);
        // _ = await Persistence(response);
        // EmitEvent(Channel, JsonSerializer.Serialize(response));
        // return response;
    }

    // private RegisterLevelDomainRequest MapToRequestForDomain(RegisterLevelCommand request)
    // {
    //     return new RegisterLevelDomainRequest
    //     {
    //         Name = request.Name,
    //         Description = request.Description,
    //     };
    // }

    // private RegisterLevelApplicationResponse MapToResponse(RegisterLevelDomainResponse role)
    // {
    //     return new RegisterLevelApplicationResponse
    //     {
    //         LevelId = role.LevelId,
    //         Name = role.Name,
    //         Description = role.Description,
    //         Disabled = role.Disabled,
    //     };
    // }

    // private async Task<TEntity> Persistence(RegisterLevelApplicationResponse response)
    // {
    //     return await _roleRepository.AddAsync(response);
    // }
}