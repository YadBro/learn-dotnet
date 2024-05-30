using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
  public class UpdateRegionRequestDto
  {
    [
      MinLength(3, ErrorMessage = "Code has to be a minimum of 3 characters"),
      MaxLength(3, ErrorMessage = "Code has to be a maximum of 3 characters"),
      Required,
    ]
    public string Name { get; set; }

    [
      MaxLength(100, ErrorMessage = "Code has to be a maximum of 100 characters"),
      Required,
    ]
    public string Code { get; set; }

    public string? RegionImageURL { get; set; }
  }
}