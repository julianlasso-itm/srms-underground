using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profiles.Domain.Aggregates.Dto.Requests;
using Profiles.Domain.Aggregates.Dto.Responses;
using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;
using Shared.Domain.Aggregate.Helpers;
using Shared.Domain.Aggregate.Interfaces;

namespace Profiles.Domain.Aggregates.Helpers
{
    internal abstract class DeleteSkillHelper : BaseHelper, IHelper<DeleteSkillDomainRequest, DeleteSkillDomainResponse>
    {
        public static DeleteSkillDomainResponse Execute(DeleteSkillDomainRequest request)
        {
            var @struct = GetSkillStruct(request);
            ValidateStructureFields(@struct);
            return new DeleteSkillDomainResponse { SkillId = @struct.SkillId.Value };
        }

        private static SkillStruct GetSkillStruct(DeleteSkillDomainRequest request)
        {
            var id = new SkillIdValueObject(request.SkillId);
            return new SkillStruct { SkillId = id };
        }
    }
}
