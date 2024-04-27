using System.Runtime.Serialization;

namespace QueryBank.Domain.Aggregates.Dto.Requests
{
    [DataContract]
    public class DeleteQuestionDomainRequest
    {
        [DataMember(Order = 1)]
        public required string QuestionId { get; set; }
    }
}
