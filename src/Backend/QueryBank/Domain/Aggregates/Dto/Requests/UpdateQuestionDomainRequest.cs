using System.Runtime.Serialization;

namespace QueryBank.Domain.Aggregates.Dto.Requests
{
    [DataContract]
    public class UpdateQuestionDomainRequest
    {
        [DataMember(Order = 1)]
        public string? Name { get; init; }

        [DataMember(Order = 2)]
        public bool? Disabled { get; init; }

        [DataMember(Order = 3)]
        public required string QuestionId { get; init; }
    }
}
