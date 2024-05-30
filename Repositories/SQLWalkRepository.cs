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

    public async Task<List<Walk>> GetWalks(string? filterOn = null, string? search = null, string? sortBy = null, bool isAscending = true, int page = 1, int limit = 10)
    {
      var walks = _dbContext.Walks.Include("Region").Include("Difficulty").AsQueryable();

      // Filtering
      if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(search) == false)
      {
        if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
        {
          walks = walks.Where(x => x.Name.Contains(search));
        }
      }

      // Sorting
      if (string.IsNullOrWhiteSpace(sortBy) == false)
      {
        if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
        {
          walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
        }
        else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
        {
          walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
        }
      }

      // Pagination
      var skipResults = (page - 1) * limit;


      var filteredWalks = await walks.Skip(skipResults).Take(limit).ToListAsync();

      return filteredWalks;
    }

    public async Task<Walk?> GetWalk(Guid id)
    {
      if (_dbContext.Walks == null)
      {
        return null;
      }

      var walk = await _dbContext.Walks.Include("Region").Include("Difficulty").FirstOrDefaultAsync(x => x.Id == id);

      return walk;
    }

    public async Task<Walk> Create(Walk walk)
    {
      _dbContext.Walks.Add(walk);
      await _dbContext.SaveChangesAsync();

      return walk;
    }

    public async Task<Walk?> Update(Guid id, Walk walk)
    {
      var isWalkExist = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

      if (isWalkExist == null)
      {
        return null;
      }

      isWalkExist.Name = walk.Name;
      isWalkExist.Description = walk.Description;
      isWalkExist.WalkImageURL = walk.WalkImageURL;
      isWalkExist.DifficultyId = walk.DifficultyId;
      isWalkExist.RegionId = walk.RegionId;

      _dbContext.Entry(isWalkExist).State = EntityState.Modified;

      try
      {
        await _dbContext.SaveChangesAsync();

        return isWalkExist;
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }
    }

    public async Task<Walk?> Delete(Guid id)
    {
      if (_dbContext.Walks == null)
      {
        return null;
      }

      var walkDomainModel = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

      if (walkDomainModel == null)
      {
        return null;
      }

      _dbContext.Walks.Remove(walkDomainModel);
      await _dbContext.SaveChangesAsync();

      return walkDomainModel;
    }
  }
}