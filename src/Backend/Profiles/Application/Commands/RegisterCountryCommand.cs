using Shared.Application.Interfaces;

namespace Profiles.Application.Commands;

public sealed class RegisterCountryCommand : ICommand
{
    public string Name { get; init; }
}
