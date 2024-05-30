using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Data
{
  public class UpdateWalkRequestDto
  {
    [
      MaxLength(100)
    ]
    public required string Name { get; set; }

    [
      MaxLength(1000)
    ]
    public required string Description { get; set; }

    [
      Range(0, 50)
    ]
    public required double LengthInKm { get; set; }

    public string? WalkImageURL { get; set; }

    public required Guid DifficultyId { get; set; }

    public required Guid RegionId { get; set; }
  }
}