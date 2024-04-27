namespace Analytics.Domain.Aggregates.Dto;

public class UpdateQuestionResponse
{
    public required string QuestionId { get; init; }
    public string? Question { get; init; }
    public bool? Disabled { get; init; }
}
