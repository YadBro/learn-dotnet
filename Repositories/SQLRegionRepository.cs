using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
  public class SQLRegionRepository : IRegionRepository
  {
    private readonly NzWalksDbContext _dbContext;

    public SQLRegionRepository(NzWalksDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<List<Region>> GetRegions()
    {
      var regions = await _dbContext.Regions.ToListAsync();

      return regions;
    }

    public async Task<Region?> GetRegion(Guid id)
    {
      if (_dbContext.Regions == null)
      {
        return null;
      }

      var region = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

      return region;
    }

    public async Task<Region> Create(Region region)
    {
      _dbContext.Regions.Add(region);
      await _dbContext.SaveChangesAsync();

      return region;
    }

    public async Task<Region?> Update(Guid id, Region region)
    {
      var isRegionExist = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

      if (isRegionExist == null)
      {
        return null;
      }

      isRegionExist.Code = region.Code;
      isRegionExist.Name = region.Name;
      isRegionExist.RegionImageURL = region.RegionImageURL;

      _dbContext.Entry(isRegionExist).State = EntityState.Modified;

      try
      {
        await _dbContext.SaveChangesAsync();

        return isRegionExist;
      }
      catch (DbUpdateConcurrencyException)
      {
        throw;
      }
    }

    public async Task<Region?> Delete(Guid id)
    {
      if (_dbContext.Regions == null)
      {
        return null;
      }

      var isRegionExist = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

      if (isRegionExist == null)
      {
        return null;
      }

      _dbContext.Regions.Remove(isRegionExist);

      await _dbContext.SaveChangesAsync();

      return isRegionExist;
    }
  }
}