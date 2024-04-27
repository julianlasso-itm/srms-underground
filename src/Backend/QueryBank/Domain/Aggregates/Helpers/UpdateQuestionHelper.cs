using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryBank.Domain.Aggregates.Dto.Requests;
using QueryBank.Domain.Aggregates.Dto.Responses;
using QueryBank.Domain.Entities;
using QueryBank.Domain.Entities.Structs;
using QueryBank.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Exceptions;
using Shared.Domain.ValueObjects;

namespace QueryBank.Domain.Aggregates.Helpers
{
    internal abstract class UpdateQuestionHelper : BaseHelper, IHelper<UpdateQuestionDomainRequest, UpdateQuestionDomainResponse>
    {
        public static UpdateQuestionDomainResponse Execute(UpdateQuestionDomainRequest data)
        {
            throw new NotImplementedException();
            // var @struct = GetQuestionStruct(data);
            // var skill = new QuestionEntity(@struct);
            // var response = new UpdateQuestionDomainResponse { QuestionId = question.QuestionId.Value };

            // if (data.Name != null)
            // {
            //     var name = new NameValueObject(data.Name);
            //     question.UpdateName(name);
            //     response.Name = skill.Name.Value;
            // }

            // if (data.Disabled != null)
            // {
            //     if (data.Disabled == true)
            //     {
            //         question.Disable();
            //     }
            //     else
            //     {
            //         question.Enable();
            //     }
            //     response.Disabled = question.Disabled.Value;
            // }

            // ValidateStructureFields(question);
            // ValidateAmountDataToBeUpdated(response);

            // return response;
        }

        private static void ValidateAmountDataToBeUpdated(UpdateQuestionDomainResponse response)
        {
            var count = response.GetType().GetProperties().Count(x => x.GetValue(response) != null);
            if (count == 1)
            {
                throw new DomainException(
                    "No data to update",
                    [new ErrorValueObject("No fields to update", "No fields to update")]
                );
            }
        }

        private static QuestionStruct GetQuestionStruct(UpdateQuestionDomainRequest data)
        {
            var id = new QuestionIdValueObject(data.QuestionId);
            return new QuestionStruct { QuestionId = id };
        }
    }
}
