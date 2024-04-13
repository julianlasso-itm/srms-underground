namespace Analytics.Domain.Aggregates.Dto;

public class RegisterLevelResponse
{
    public required string LevelId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required bool Disabled { get; init; }
}
