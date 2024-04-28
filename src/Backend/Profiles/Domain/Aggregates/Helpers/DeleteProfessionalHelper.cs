using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
    internal class DeleteProfessionalHelper
        : BaseHelper,
            IHelper<DeleteProfessionalDomainRequest, DeleteProfessionalDomainResponse>
    {
        public static DeleteProfessionalDomainResponse Execute(
            DeleteProfessionalDomainRequest request
        )
        {
            var @struct = GetProfessionalStruct(request);
            ValidateStructureFields(@struct);
            return new DeleteProfessionalDomainResponse
            {
                ProfessionalId = @struct.ProfessionalId.Value
            };
        }

        private static ProfessionalStruct GetProfessionalStruct(
            DeleteProfessionalDomainRequest request
        )
        {
            var id = new ProfessionalIdValueObject(request.ProfessionalId);
            return new ProfessionalStruct { ProfessionalId = id };
        }
    }
}
