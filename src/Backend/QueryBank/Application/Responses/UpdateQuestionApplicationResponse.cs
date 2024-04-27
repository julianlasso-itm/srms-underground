namespace QueryBank.Application.Responses
{
    public class UpdateQuestionApplicationResponse
    {
        public required string QuestionId { get; set; }
        public string? Name { get; set; }
        public bool? Disabled { get; set; }
    }
}
