using Shared.Application.Interfaces;

namespace Analytics.Application.Commands;

public sealed class DeleteQuestionCommand : ICommand
{
    public required string QuestionId { get; init; }
}
