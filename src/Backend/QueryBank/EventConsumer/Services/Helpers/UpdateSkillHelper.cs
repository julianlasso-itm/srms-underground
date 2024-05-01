using QueryBank.Application.Commands;
using QueryBank.EventConsumer.Services.Dto.Requests;
using QueryBank.EventConsumer.Services.Helpers.Base;

namespace QueryBank.EventConsumer.Services.Helpers
{
  public class UpdateSkillHelper : BaseHelperServiceInfrastructure
  {
    public static async Task UpdateSkillAsync(UpdateSkillQueryBankRequest request)
    {
      var newUserCommand = MapToUpdateSkillQueryBankCommand(request);
      await Application.UpdateSkill(newUserCommand);
    }

    private static UpdateSkillCommand MapToUpdateSkillQueryBankCommand(
      UpdateSkillQueryBankRequest request
    )
    {
      return new UpdateSkillCommand
      {
        SkillId = request.SkillId!,
        SubSkillId = request.SubSkillId,
        Name = request.Name,
        Disabled = request.Disable
      };
    }
  }
}
