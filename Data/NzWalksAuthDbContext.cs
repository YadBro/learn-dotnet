using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
  public class NzWalksAuthDbContext : IdentityDbContext
  {
    public NzWalksAuthDbContext(DbContextOptions<NzWalksAuthDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      var readerRoleId = Guid.NewGuid().ToString();
      var writerRoleId = Guid.NewGuid().ToString();

      var roles = new List<IdentityRole>{
        new(){
          Id = readerRoleId,
          ConcurrencyStamp = readerRoleId,
          Name = "Reader",
          NormalizedName = "Reader".ToUpper(),
        },
        new(){
          Id = writerRoleId,
          ConcurrencyStamp = writerRoleId,
          Name = "Writer",
          NormalizedName = "Writer".ToUpper(),
        },
      };


      builder.Entity<IdentityRole>().HasData(roles);
    }
  }
}