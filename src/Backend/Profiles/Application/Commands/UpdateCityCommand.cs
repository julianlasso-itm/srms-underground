using Shared.Application.Interfaces;

namespace Profiles.Application.Commands;

public sealed class UpdateCityCommand : ICommand
{
    public required string CityId { get; init; }
    public string? ProvinceId { get; init; }
    public string? Name { get; init; }
    public bool? Disable { get; init; }
}
