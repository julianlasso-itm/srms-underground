using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Entities;
using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;
using Shared.Domain.Exceptions;
using Shared.Domain.ValueObjects;

namespace Profiles.Domain.Aggregates.Helpers
{
    internal class UpdateProfessionalHelper
        : BaseHelper,
            IHelper<UpdateProfessionalDomainRequest, UpdateProfessionalDomainResponse>
    {
        public static UpdateProfessionalDomainResponse Execute(UpdateProfessionalDomainRequest data)
        {
            var @struct = GetProfessionalStruct(data);
            var professional = new ProfessionalEntity(@struct);
            var response = new UpdateProfessionalDomainResponse
            {
                ProfessionalId = professional.ProfessionalId.Value
            };

            if (data.Name != null)
            {
                var name = new NameValueObject(data.Name);
                professional.UpdateName(name);
                response.Name = professional.Name.Value;
            }

            if (data.Email != null)
            {
                professional.UpdateEmail(new EmailValueObject(data.Email));
                response.Email = professional.Email.Value;
            }

            if (data.Disabled != null)
            {
                if (data.Disabled == true)
                {
                    professional.Disable();
                }
                else
                {
                    professional.Enable();
                }
                response.Disabled = professional.Disabled.Value;
            }

            ValidateStructureFields(professional);
            ValidateAmountDataToBeUpdated(response);

            return response;
        }

        private static void ValidateAmountDataToBeUpdated(UpdateProfessionalDomainResponse response)
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

        private static ProfessionalStruct GetProfessionalStruct(
            UpdateProfessionalDomainRequest data
        )
        {
            var id = new ProfessionalIdValueObject(data.ProfessionalId);
            return new ProfessionalStruct { ProfessionalId = id };
        }
    }
}
