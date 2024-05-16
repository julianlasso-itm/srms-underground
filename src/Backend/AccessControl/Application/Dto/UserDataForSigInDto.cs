namespace AccessControlApplication.Dto
{
  public class UserDataForSigInDto
  {
    public required string UserId { get; init; }
    public required string Name { get; init; }
    public required string Photo { get; init; }
    public required List<string> Roles { get; init; }
  }
}
