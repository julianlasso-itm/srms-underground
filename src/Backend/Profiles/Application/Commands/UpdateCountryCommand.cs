using Shared.Application.Interfaces;

namespace Profiles.Application.Commands;

public sealed class UpdateCountryCommand : ICommand
{
    public required string CountryId { get; init; }
    public string? Name { get; init; }
    public bool? Disable { get; init; }
}
