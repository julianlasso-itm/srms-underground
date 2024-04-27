namespace Analytics.Domain.Aggregates.Dto;

public class RegisterQuestionResponse
{
    public required string QuestionlId { get; init; }
    public required string Question { get; init; }
    public required bool Disabled { get; init; }
}
