using ApiGateway.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared.Infrastructure.ProtocolBuffers.AccessControl.Requests;

namespace Infrastructure.DataAnnotations
{
  [AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true,
    Inherited = true
  )]
  public class PermissionsAttribute : Attribute, IAsyncActionFilter
  {
    public string? Data { get; set; }

    public async Task OnActionExecutionAsync(
      ActionExecutingContext context,
      ActionExecutionDelegate next
    )
    {
      var accessControlServices =
        context.HttpContext.RequestServices.GetRequiredService<AccessControlService>();
      var token = context
        .HttpContext.Request.Headers.Authorization.ToString()
        .Replace("Bearer ", "");
      var data = await accessControlServices.VerifyTokenAsync(
        new VerifyTokenAccessControlRequest { Token = token }
      );
      if (Data != null && data.Roles.Contains(Data))
      {
        await next();
      }
      else
      {
        context.Result = new UnauthorizedResult();
      }
    }
  }
}
