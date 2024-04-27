using Shared.Application.Interfaces;

namespace Analytics.Application.Commands;

public sealed class RegisterQuestionCommand : ICommand
{
    public required string Question { get; init; }
}
