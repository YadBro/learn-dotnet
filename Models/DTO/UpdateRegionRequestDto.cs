namespace NZWalks.API.Models.DTO
{
  public class UpdateRegionRequestDto
  {
    public string Name { get; set; }

    public string Code { get; set; }

    public string? RegionImageURL { get; set; }
  }
}