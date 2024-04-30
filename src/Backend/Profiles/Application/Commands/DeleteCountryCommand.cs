using Shared.Application.Interfaces;

namespace Profiles.Application.Commands
{
  public sealed class DeleteCountryCommand : ICommand
  {
    public required string CountryId { get; init; }
  }
}
