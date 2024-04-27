using Shared.Application.Interfaces;

namespace Analytics.Application.Commands;

public sealed class UpdateQuestionCommand : ICommand
{
    public required string QuestionId { get; init; }
    public string? Question { get; init; }
    public bool? Disable { get; init; }
}
