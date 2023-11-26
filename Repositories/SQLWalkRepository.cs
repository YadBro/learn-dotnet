using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
  public class SQLWalkRepository : IWalkRepository
  {
    private readonly NzWalksDbContext _dbContext;

    public SQLWalkRepository(NzWalksDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<List<Walk>> GetWalks()
    {
      var walks = await _dbContext.Walks.Include("Region").Include("Difficulty").ToListAsync();

      return walks;
    }

    public async Task<Walk> Create(Walk walk)
    {
      _dbContext.Walks.Add(walk);
      await _dbContext.SaveChangesAsync();

      return walk;
    }
  }
}