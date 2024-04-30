namespace Profiles.Application.Responses
{
  public class GetProfessionalsApplicationResponse<TProfessionalEntity>
  {
    public IEnumerable<TProfessionalEntity> Professionals { get; init; }
    public int Total { get; init; }
  }
}
