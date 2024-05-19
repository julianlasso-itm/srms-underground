using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Infrastructure.Dto
{
  public class RegisterUserRequestDto
  {
    [FromForm(Name = "name")]
    public required string Name { get; set; }

    [FromForm(Name = "email")]
    public required string Email { get; set; }

    [FromForm(Name = "password")]
    public required string Password { get; set; }

    [FromForm(Name = "avatar")]
    public required IFormFile Avatar { get; set; }

    [FromForm(Name = "cityId")]
    public required string CityId { get; set; }
  }
}
