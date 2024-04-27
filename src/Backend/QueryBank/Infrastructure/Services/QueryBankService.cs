namespace QueryBank.Infrastructure.Services
{
    public class QueryBankService
    {
        private readonly ApplicationService _applicationService;

        // public QueryBankService(ApplicationService applicationService)
        // {
        //     _applicationService = applicationService;
        // }

        // public async Task<DeleteQuestionResponse> DeleteQuestionAsync(DeleteQuestionRequest request, CallContext context = default)
        // {
        //     DeleteQuestionHelper.SetApplication(_applicationService.GetApplication());
        //     return await DeleteQuestionHelper.DeleteQuestionAsync(request);
        // }

        // public async Task<GetQuestionsResponse> GetQuestionAsync(GetQuestionsRequest request, CallContext context = default)
        // {
        //     GetQuestionsHelper.SetApplication(_applicationService.GetApplication());
        //     return await GetQuestionsHelper.GetQuestionsAsync(request);
        // }

        // public async Task<RegisterQuestionResponse> RegisterQuestionAsync(RegisterQuestionRequest request, CallContext context = default)
        // {
        //     RegisterQuestionHelper.SetApplication(_applicationService.GetApplication());
        //     return await RegisterQuestionHelper.RegisterQuestionAsync(request);
        // }

        // public async Task<UpdateQuestionResponse> UpdateQuestionRoleAsync(UpdateQuestionRequest request, CallContext context = default)
        // {
        //     UpdateQuestionHelper.SetApplication(_applicationService.GetApplication());
        //     return await UpdateQuestionHelper.UpdateQuestionAsync(request);
        // }

    }
}
