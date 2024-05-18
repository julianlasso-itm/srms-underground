using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Infrastructure.Dto
{
  public class UpdateUserRequestDto
  {
    [FromForm(Name = "name")]
    public string? Name { get; set; }

    [FromForm(Name = "avatar")]
    public IFormFile? Avatar { get; set; }

    [FromForm(Name = "disabled")]
    public bool? Disabled { get; set; }
  }
}
