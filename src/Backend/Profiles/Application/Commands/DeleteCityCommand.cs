using Shared.Application.Interfaces;

namespace Profiles.Application.Commands;

public sealed class DeleteCityCommand : ICommand
{
    public required string CityId { get; init; }
}
