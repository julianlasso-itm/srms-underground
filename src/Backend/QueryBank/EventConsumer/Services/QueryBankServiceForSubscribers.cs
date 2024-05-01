using QueryBank.EventConsumer.Services.Dto.Requests;
using QueryBank.EventConsumer.Services.Helpers;
using QueryBank.Infrastructure.Services;

namespace QueryBank.EventConsumer.Services
{
  public class QueryBankServiceForSubscribers
  {
    private readonly ApplicationService _applicationService;

    public QueryBankServiceForSubscribers(ApplicationService applicationService)
    {
      _applicationService = applicationService;
    }

    public async Task DeleteSkillAsync(DeleteSkillQueryBankRequest request)
    {
      DeleteSkillHelper.SetApplication(_applicationService.GetApplication());
      await DeleteSkillHelper.DeleteSkillAsync(request);
    }

    public async Task RegisterSkillAsync(RegisterSkillQueryBankRequest request)
    {
      RegisterSkillHelper.SetApplication(_applicationService.GetApplication());
      await RegisterSkillHelper.RegisterSkillAsync(request);
    }

    public async Task UpdateSkillRoleAsync(UpdateSkillQueryBankRequest request)
    {
      UpdateSkillHelper.SetApplication(_applicationService.GetApplication());
      await UpdateSkillHelper.UpdateSkillAsync(request);
    }
  }
}
