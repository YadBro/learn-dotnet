using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
  public interface IWalkRepository
  {
    Task<List<Walk>> GetWalks();

    Task<Walk> Create(Walk walk);
  }
}