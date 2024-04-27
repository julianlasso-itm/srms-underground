using System.Runtime.Serialization;

namespace QueryBank.Application.Commands
{
    public class DeleteQuestionCommand
    {
        public required string QuestionId { get; set; }
    }
}
