using Profiles.Application.Commands;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Profiles.Infrastructure.Services.Helpers.Base;
using Shared.Common;
using Shared.Common;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Requests;
using Shared.Infrastructure.ProtocolBuffers.Profiles.Responses;

namespace Profiles.Infrastructure.Services.Helpers
{
  public class GetProfessionalHelper : BaseHelperServiceInfrastructure
  {
    public static async Task<Result<GetProfessionalProfilesResponse>> GetProfessionalsAsync(
      GetProfessionalsProfilesRequest request
    )
    {
      var newUserCommand = MapToGetProfessionalsCommand(request);
      var response = await Application.GetProfessional(newUserCommand);

      if (response.IsFailure)
      {
        return Response<GetProfessionalProfilesResponse>.Failure(
          response.Message,
          response.Code,
          response.Details
        );
      }

      return Response<GetProfessionalProfilesResponse>.Success(
        MapToGetProfessionalsResponse(response.Data)
      );
    }

    private static GetProfessionalsCommand MapToGetProfessionalsCommand(
      GetProfessionalsProfilesRequest request
    )
    {
      return new GetProfessionalsCommand
      {
        Page = request.Page,
        Limit = request.Limit,
        Filter = request.Filter,
        Sort = request.Sort,
        Order = request.Order
      };
    }

    private static GetProfessionalProfilesResponse MapToGetProfessionalsResponse(
      GetProfessionalsApplicationResponse<ProfessionalModel> data
    )
    {
      return new GetProfessionalProfilesResponse
      {
        Professionals = data
          .Professionals.Select(professional => new ProfessionalProfiles
          {
            ProfessionalId = professional.ProfessionalId.ToString(),
            Name = professional.Name,
            Email = professional.Email,
            Disabled = professional.Disabled
          })
          .ToList(),
        Total = data.Total
      };
    }
  }
}
