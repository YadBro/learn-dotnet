using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
  public class NzWalksDbContext : DbContext
  {
    public NzWalksDbContext(DbContextOptions<NzWalksDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }
    public DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      var difficulties = new List<Difficulty>(){
        new() {
          Id = Guid.NewGuid(),
          Name = "Easy",
        },
        new() {
          Id = Guid.NewGuid(),
          Name = "Medium",
        },
        new() {
          Id = Guid.NewGuid(),
          Name = "Hard",
        }
      };

      // Seed difficulties to the database
      modelBuilder.Entity<Difficulty>().HasData(difficulties);


      var regions = new List<Region>() {
        new() {
          Id = Guid.NewGuid(),
          Name = "Indonesia",
          Code = "ID",
          RegionImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/Flag_of_Indonesia.svg/510px-Flag_of_Indonesia.svg.png",
        },
        new() {
          Id = Guid.NewGuid(),
          Name = "Malaysia",
          Code = "MY",
          RegionImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/66/Flag_of_Malaysia.svg/510px-Flag_of_Malaysia.svg.png",
        },
        new() {
          Id = Guid.NewGuid(),
          Name = "Palestine",
          Code = "PS",
          RegionImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/00/Flag_of_Palestine.svg/510px-Flag_of_Palestine.svg.png",
        },
        new() {
          Id = Guid.NewGuid(),
          Name = "Testing",
          Code = "TG",
          RegionImageURL = null,
        }
      };

      // Seed regions to the database
      modelBuilder.Entity<Region>().HasData(regions);

      var walks = new List<Walk>() {
        new() {
          Id = Guid.NewGuid(),
          Name = "Mount Victoria Loop",
          Description = "This scenic walk takes you around the top of Mount Victoria, offering stunning views of Wellington and its harbor.",
          LengthInKm = 3.5,
          WalkImageURL = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
          DifficultyId = difficulties[0].Id,
          RegionId = regions[0].Id,
        },
        new() {
          Id = Guid.NewGuid(),
          Name = "Makara Beach Walkway",
          Description = "This walk takes you along the wild and rugged coastline of Makara Beach, with breathtaking views of the Tasman Sea.",
          LengthInKm = 8.2,
          WalkImageURL = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
          DifficultyId = difficulties[1].Id,
          RegionId = regions[1].Id,
        },
        new() {
          Id = Guid.NewGuid(),
          Name = "Botanic Garden Walk",
          Description = "Explore the beautiful Botanic Garden of Wellington on this leisurely walk, with a wide variety of plants and flowers to admire.",
          DifficultyId = difficulties[2].Id,
          RegionId = regions[2].Id,
        }
      };

      // Seed walks to database
      modelBuilder.Entity<Walk>().HasData(walks);
    }
  }
}