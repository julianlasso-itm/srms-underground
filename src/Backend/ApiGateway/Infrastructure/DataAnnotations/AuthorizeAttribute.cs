using System.Text.Json;
using ApiGateway.Infrastructure.Services;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared.Infrastructure.Exceptions;
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
    public string[]? Data { get; set; }
    const string ContentType = "application/json";

    public PermissionsAttribute() { }

    public PermissionsAttribute(params string[] data)
    {
      Data = data;
    }

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
      try
      {
        var data = await accessControlServices.VerifyTokenAsync(
          new VerifyTokenAccessControlRequest { Token = token }
        );

        if (Data != null && !Data.Contains(data.Roles.FirstOrDefault()))
        {
          context.Result = new ContentResult
          {
            Content = JsonSerializer.Serialize(
              new { Message = "Unauthorized" }
            ),
            StatusCode = StatusCodes.Status401Unauthorized,
            ContentType = ContentType
          };
          return;
        }
        context.HttpContext.Items.Add("UserId", data.UserId);
        await next();
      }
      catch (RpcException e)
      {
        context.Result = new ContentResult
        {
          Content = e.Status.Detail,
          StatusCode = (int)StatusCodeConverter.GetHttpStatusCodeFromGrpcStatus(e.StatusCode),
          ContentType = ContentType
        };
      }
    }
  }
}
