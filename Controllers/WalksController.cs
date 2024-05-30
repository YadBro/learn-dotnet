using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
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
    private readonly ILogger<WalksController> _logger;

    public WalksController(NzWalksDbContext dbContext, IWalkRepository walkRepository, IMapper mapper, ILogger<WalksController> logger)
    {
      _dbContext = dbContext;
      _walkRepository = walkRepository;
      _mapper = mapper;
      _logger = logger;
    }

    // GET WALKS
    // GET: /api/walks?filterOn=Name&search=Track
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Walk>>> GetWalks([FromQuery] string? filterOn, [FromQuery] string? search, [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int? page, [FromQuery] int? limit)
    {
      var walksDomain = await _walkRepository.GetWalks(filterOn, search, sortBy, isAscending ?? true, page ?? 1, limit ?? 10);

      _logger.LogInformation($"The data is {JsonSerializer.Serialize(walksDomain)}");
      var walksDto = _mapper.Map<List<WalkDto>>(walksDomain);

      return Ok(walksDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Walk>> GetRegion(Guid id)
    {
      var walkDomainModel = await _walkRepository.GetWalk(id);

      if (walkDomainModel == null)
      {
        return NotFound();
      }

      var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

      return Ok(walkDto);
    }

    [HttpPost]
    [ValidateModel]
    public async Task<ActionResult<AddWalkRequestDto>> PostWalk(AddWalkRequestDto addWalkRequestDto)
    {

      if (_dbContext.Walks == null)
      {
        return Problem("Entity set 'NzWalksDbContext.Walks' is null.");
      }

      var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);

      walkDomainModel = await _walkRepository.Create(walkDomainModel);

      var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

      return CreatedAtAction("GetWalk", new { id = walkDto.Id }, walkDto);
    }

    [HttpPut("{id}")]
    [ValidateModel]
    public async Task<IActionResult> PutWalk(Guid id, UpdateWalkRequestDto updateWalkRequestDto)
    {

      var walkDomainModel = _mapper.Map<Walk>(updateWalkRequestDto);

      walkDomainModel = await _walkRepository.Update(id, walkDomainModel);

      if (walkDomainModel == null)
      {
        return NotFound();
      }

      var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

      return Ok(walkDto);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult?> DeleteWalk(Guid id)
    {
      var walkDomainModel = await _walkRepository.Delete(id);

      if (walkDomainModel == null)
      {
        return NotFound();
      }

      var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

      return Ok(walkDto);
    }
  }
}