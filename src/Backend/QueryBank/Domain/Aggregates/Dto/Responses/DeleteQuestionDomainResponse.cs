using System.Runtime.Serialization;

namespace QueryBank.Domain.Aggregates.Dto.Responses
{
    [DataContract]
    public class DeleteQuestionDomainResponse
    {
        [DataMember(Order = 1)]
        public string QuesionId { get; set; }
    }
}
