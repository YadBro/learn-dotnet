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
    public class RegionsController : ControllerBase
    {
        private readonly NzWalksDbContext _dbContext;
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(NzWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        // GET: api/Regions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
            var regionsDomain = await _regionRepository.GetRegions();

            var regionsDto = _mapper.Map<List<RegionDto>>(regionsDomain);

            return Ok(regionsDto);
        }

        // GET: api/Regions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegion(Guid id)
        {
            var regionDomain = await _regionRepository.GetRegion(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            var regionDto = _mapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }

        // PUT: api/Regions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(Guid id, UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = _mapper.Map<Region>(updateRegionRequestDto);

            regionDomainModel = await _regionRepository.Update(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }

        // POST: api/Regions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddRegionRequestDto>> PostRegion(AddRegionRequestDto addRegionRequestDto)
        {
            if (_dbContext.Regions == null)
            {
                return Problem("Entity set 'NzWalksDbContext.Regions'  is null.");
            }

            var regionDomainModel = _mapper.Map<Region>(addRegionRequestDto);


            regionDomainModel = await _regionRepository.Create(regionDomainModel);

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction("GetRegion", new { id = regionDto.Id }, regionDto);
        }

        // DELETE: api/Regions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var regionDomainModel = await _regionRepository.Delete(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }
    }
}
