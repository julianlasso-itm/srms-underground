namespace Analytics.Application.Responses;

public sealed class UpdateLevelApplicationResponse
{
    public required string LevelId { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public bool? Disabled { get; init; }
}
