namespace Analytics.Domain.Aggregates.Dto;

public class UpdateQuestion
{
    public required string QuestionlId { get; init; }
    public string? Question { get; init; }
    public bool? Disabled { get; init; }
}
