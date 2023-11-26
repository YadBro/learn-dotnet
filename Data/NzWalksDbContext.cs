using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
  public class NzWalksDbContext : DbContext
  {
    public NzWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }

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
    }
  }
}