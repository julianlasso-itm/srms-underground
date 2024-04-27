using QueryBank.Application.Repositories;
using QueryBank.Application.Responses;
using QueryBank.Domain.Aggregates.Interfaces;
using QueryBank.Infrastructure.Services.helpers;
using Shared.Application.Base;

namespace QueryBank.Application.UseCases
{
    internal class GetQuestionsUseCase<TQuestionEntity> : BaseUseCase<GetQuestionsCommand, GetQuestionsApplicationResponse<TQuestionEntity>, ICatalogAggregateRoot> 
        where TQuestionEntity : class
    {

        private readonly IQuestionRepository<TQuestionEntity> _questionRepository;

        public GetQuestionsUseCase(ICatalogAggregateRoot aggregateRoot, IQuestionRepository<TQuestionEntity> questionRepository) : base(aggregateRoot)
        {
            _questionRepository = questionRepository;
        }

        public override async Task<GetQuestionsApplicationResponse<TQuestionEntity>> Handle(GetQuestionsCommand request)
        {
            var data = await QueryQuestions(request);
            var count = await QueryQuestionsCount(request);
            var response = MapToResponse(data, count);
            return response;
        }

        private GetQuestionsApplicationResponse<TQuestionEntity> MapToResponse(IEnumerable<TQuestionEntity> data, int count)
        {
            return new GetQuestionsApplicationResponse<TQuestionEntity>
            {
                Questions = data,
                Total = count
            };
        }

        private async Task<int> QueryQuestionsCount(GetQuestionsCommand request)
        {
            return await _questionRepository.GetCountAsync(request.Filter);
        }

        private async Task<IEnumerable<TQuestionEntity>> QueryQuestions(GetQuestionsCommand request)
        {
            return await _questionRepository.GetWithPaginationAsync(
               request.Page,
            request.Limit,
            request.Sort!,
            request.Order!,
            request.Filter
                );
        }
    }
}
