namespace Analytics.Application.Responses;

public sealed class UpdateQuestionApplicationResponse
{
    public required string QuestionId { get; init; }
    public required string Question { get; init; }
    public required bool Disabled { get; init; }
}
