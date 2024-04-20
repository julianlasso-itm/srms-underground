namespace AccessControl.Domain.Aggregates.Dto.Request;

public class RegisterRoleDomainRequest
{
    public required string Name { get; init; }
    public string? Description { get; init; }
}
