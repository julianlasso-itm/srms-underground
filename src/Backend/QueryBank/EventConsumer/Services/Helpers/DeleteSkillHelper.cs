using QueryBank.Application.Commands;
using QueryBank.EventConsumer.Services.Dto.Requests;
using QueryBank.EventConsumer.Services.Helpers.Base;

namespace QueryBank.EventConsumer.Services.Helpers
{
  public class DeleteSkillHelper : BaseHelperServiceInfrastructure
  {
    public static async Task DeleteSkillAsync(DeleteSkillQueryBankRequest request)
    {
      var deleteSkillCommand = MapToDeleteSkillCommand(request);
      await Application.DeleteSkill(deleteSkillCommand);
    }

    private static DeleteSkillCommand MapToDeleteSkillCommand(DeleteSkillQueryBankRequest request)
    {
      return new DeleteSkillCommand { SkillId = request.SkillId };
    }
  }
}
