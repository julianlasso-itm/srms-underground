using System.Runtime.Serialization;

namespace QueryBank.Domain.Aggregates.Dto.Responses
{
    [DataContract]
    public class RegisterQuestionDomainResponse
    {
        [DataMember(Order = 1)]
        public required string QuestionId { get; init; }

        [DataMember(Order = 2)]
        public string Name { get; init; }

        [DataMember(Order = 3)]
        public bool Disabled { get; init; }
    }
}
