namespace Analytics.Domain.Aggregates.Dto.Responses;

public class RegisterLevelDomainResponse
{
    public required string LevelId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required bool Disabled { get; init; }
}
