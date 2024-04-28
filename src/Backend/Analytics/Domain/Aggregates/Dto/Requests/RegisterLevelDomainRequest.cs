namespace Analytics.Domain.Aggregates.Dto.Requests;

public class RegisterLevelDomainRequest
{
    public required string Name { get; init; }
    public string? Description { get; init; }
}
