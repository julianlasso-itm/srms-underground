namespace AccessControl.Domain.Aggregates.Dto;

public class RegisterRole
{
    public required string Name { get; init; }
    public string? Description { get; init; }
}
