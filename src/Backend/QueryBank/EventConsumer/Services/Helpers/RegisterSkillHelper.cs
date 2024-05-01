using QueryBank.Application.Commands;
using QueryBank.EventConsumer.Services.Dto.Requests;
using QueryBank.EventConsumer.Services.Helpers.Base;

namespace QueryBank.EventConsumer.Services.Helpers
{
  public class RegisterSkillHelper : BaseHelperServiceInfrastructure
  {
    public static async Task RegisterSkillAsync(RegisterSkillQueryBankRequest request)
    {
      var newUserCommand = MapToNewUserCommand(request);
      await Application.RegisterSkill(newUserCommand);
    }

    private static RegisterSkillCommand MapToNewUserCommand(RegisterSkillQueryBankRequest request)
    {
      return new RegisterSkillCommand
      {
        SkillId = request.SkillId,
        SubSkillId = request.SubSkillId,
        Name = request.Name,
        Disable = request.Disable,
      };
    }
  }
}
