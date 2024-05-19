namespace AccessControl.Domain.Aggregates.Dto.Requests
{
  public sealed class ResetPasswordDomainRequest
  {
    public required string Password { get; set; }
  }
}
