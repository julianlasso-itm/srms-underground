using System.Runtime.Serialization;

namespace QueryBank.Domain.Aggregates.Dto.Requests
{
    [DataContract]
    public class RegisterQuestionDomainRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; init; }

    }
}
