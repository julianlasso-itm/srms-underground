using Profiles.Application.Commands;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Domain.Aggregates.Interfaces;
using Shared.Application.Base;

namespace Profiles.Application.UseCases
{
    internal class GetProfessionalsUseCase<TProfessionalEntity>
        : BaseUseCase<
            GetProfessionalsCommand,
            GetProfessionalsApplicationResponse<TProfessionalEntity>,
            IPersonnelAggregateRoot
        >
        where TProfessionalEntity : class
    {
        private readonly IProfessionalRepository<TProfessionalEntity> _professionalRepository;

        public GetProfessionalsUseCase(
            IPersonnelAggregateRoot aggregateRoot,
            IProfessionalRepository<TProfessionalEntity> professionalRepository
        )
            : base(aggregateRoot)
        {
            _professionalRepository = professionalRepository;
        }

        public override async Task<GetProfessionalsApplicationResponse<TProfessionalEntity>> Handle(
            GetProfessionalsCommand request
        )
        {
            var data = await QueryProfessionals(request);
            var count = await QueryProfessionalsCount(request);
            var response = MapToResponse(data, count);
            return response;
        }

        private GetProfessionalsApplicationResponse<TProfessionalEntity> MapToResponse(
            IEnumerable<TProfessionalEntity> data,
            int count
        )
        {
            return new GetProfessionalsApplicationResponse<TProfessionalEntity>
            {
                Professionals = data,
                Total = count
            };
        }

        private async Task<int> QueryProfessionalsCount(GetProfessionalsCommand request)
        {
            return await _professionalRepository.GetCountAsync(request.Filter);
        }

        private async Task<IEnumerable<TProfessionalEntity>> QueryProfessionals(
            GetProfessionalsCommand request
        )
        {
            return await _professionalRepository.GetWithPaginationAsync(
                request.Page,
                request.Limit,
                request.Sort!,
                request.Order!,
                request.Filter
            );
        }
    }
}
