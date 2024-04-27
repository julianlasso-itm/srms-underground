using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Entities;
using QueryBank.Domain.Entities.Structs;
using QueryBank.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace QueryBank.Domain.Aggregates.Helpers;

internal abstract class RegisterQuestionHelper
    : BaseHelper,
        IHelper<RegisterQuestionDomainRequest, RegisterQuestionDomainResponse>
{
    public static RegisterQuestionDomainResponse Execute(RegisterQuestionDomainRequest request)
    {
        throw new NotImplementedException();
        // var @struct = GetQuestionStruct(request);
        // ValidateStructureFields(@struct);

        // var role = new QuestionEntity();
        // role.Register(@struct.Name, @struct.Description);

        // return new RegisterQuestionDomainResponse
        // {
        //     QuestionId = role.QuestionId.Value,
        //     Name = role.Name.Value,
        //     Disabled = role.Disabled.Value,
        // };
    }

    private static QuestionStruct GetQuestionStruct(RegisterQuestionDomainRequest request)
    {
        throw new NotImplementedException();
        // var name = new NameValueObject(request.Name);
        // var description =
        //     request.Description != null ? new DescriptionValueObject(request.Description) : null;

        // return new QuestionStruct { Name = name, Description = description };
    }
}
