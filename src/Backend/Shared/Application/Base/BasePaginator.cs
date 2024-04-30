using System.ComponentModel.DataAnnotations;
using Shared.Application.Interfaces;

namespace Shared.Application.Base
{
  public abstract class BasePaginator : ICommand
  {
    [Range(1, int.MaxValue, ErrorMessage = "Page must be greater than 0")]
    [Required(ErrorMessage = "Page is required")]
    public required int Page { get; init; }

    [Range(1, int.MaxValue, ErrorMessage = "Limit must be greater than 0")]
    [Required(ErrorMessage = "Limit is required")]
    public required int Limit { get; init; }

    [MinLength(1, ErrorMessage = "Filter must be a string")]
    public string? Filter { get; init; }

    [StringLength(1, ErrorMessage = "FilterBy must be a string")]
    public string? FilterBy { get; init; }

    [RegularExpression(@"^[a-zA-Z]+(?:\s[a-zA-Z]+)*$", ErrorMessage = "Sort must be a string")]
    public string? Sort { get; init; }

    [RegularExpression(@"^(asc|desc)$", ErrorMessage = "Order must be 'asc' or 'desc'")]
    public string? Order { get; init; } = "asc";
  }
}
