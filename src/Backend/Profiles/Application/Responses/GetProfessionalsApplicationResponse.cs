namespace Profiles.Application.Responses
{
    public class GetProfessionalsApplicationResponse<TProfessionalEntity>
    {
        public IEnumerable<TProfessionalEntity> Professionals { get; set; }
        public int Total { get; set; }
    }
}
