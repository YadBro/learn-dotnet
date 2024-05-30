using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
  public interface IWalkRepository
  {
    Task<List<Walk>> GetWalks(string? filterOn = null, string? search = null, string? sortBy = null, bool isAscending = true, int page = 1, int limit = 10);

    Task<Walk?> GetWalk(Guid id);

    Task<Walk> Create(Walk walk);

    Task<Walk?> Update(Guid id, Walk walk);

    Task<Walk?> Delete(Guid id);
  }
}