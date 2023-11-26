using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class WalksController : ControllerBase
  {
    private readonly NzWalksDbContext _dbContext;
    private readonly IWalkRepository _walkRepository;
    private readonly IMapper _mapper;

    public WalksController(NzWalksDbContext dbContext, IWalkRepository walkRepository, IMapper mapper)
    {
      _dbContext = dbContext;
      _walkRepository = walkRepository;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Walk>>> GetWalks()
    {
      var walksDomain = await _walkRepository.GetWalks();

      var walksDto = _mapper.Map<List<WalkDto>>(walksDomain);

      return Ok(walksDto);
    }

    [HttpPost]
    public async Task<ActionResult<AddWalkRequestDto>> PostWalk(AddWalkRequestDto addWalkRequestDto)
    {
      if (_dbContext.Walks == null)
      {
        return Problem("Entity set 'NzWalksDbContext.Walks' is null.");
      }

      var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);

      walkDomainModel = await _walkRepository.Create(walkDomainModel);

      var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

      // return CreatedAtAction("GetRegion", new { id = walkDto.Id }, walkDto);

      return Ok(walkDto);
    }
  }
}