namespace QueryBank.Infrastructure.Services.helpers
{
    public class UpdateQuestionCommand
    {
        public required string QuestionId { get; set; }
        public string? Name { get; set; }
        public bool? Disabled { get; set; }
    }
}
