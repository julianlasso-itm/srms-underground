using Shared.Application.Interfaces;

namespace Profiles.Application.Commands;

public sealed class RegisterCityCommand : ICommand
{
    public string Name { get; init; }
    public string ProvinceId { get; init; }
}
