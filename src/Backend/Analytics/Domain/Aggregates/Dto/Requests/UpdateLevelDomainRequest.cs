namespace Analytics.Domain.Aggregates.Dto.Requests
{
  public class UpdateLevelDomainRequest
  {
    public required string LevelId { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
    public bool? Disable { get; init; }
  }
}
