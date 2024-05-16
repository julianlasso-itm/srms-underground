using Microsoft.AspNetCore.Mvc.Filters;

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

    public PermissionsAttribute() { }

    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      Console.WriteLine("Data: " + Data);
      Console.WriteLine(
        context.HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "")
      );
      return next();
    }
  }
}
