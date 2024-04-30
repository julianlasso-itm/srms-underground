namespace Analytics.Domain.Aggregates.Dto.Responses
{
  public class UpdateLevelDomainResponse
  {
    public required string LevelId { get; init; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? Disabled { get; set; }
  }
}
