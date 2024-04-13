namespace Analytics.Domain.Aggregates.Dto;

public class UpdateLevel
{
    public required string LevelId { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public bool? Disabled { get; init; }
}
