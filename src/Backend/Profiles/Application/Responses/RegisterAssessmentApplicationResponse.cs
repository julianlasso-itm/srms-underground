namespace Profiles.Application.Responses
{
  public class RegisterAssessmentApplicationResponse
  {
    public required string AssessmentId { get; init; }
    public required string ProfessionalId { get; init; }
    public required string RoleId { get; init; }
    public required string SquadId { get; init; }
  }
}
