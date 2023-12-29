using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NzTrails.Api.Data;
using NzTrails.Api.Models.Domain;
using NzTrails.Api.Models.DTO;
using NzTrails.Api.Repositories.Interfaces;

namespace NzTrails.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly NzWalksDbContext _nzWalksDbContext;
        private readonly IRegionRepo _regionRepo;
        private readonly IMapper _mapper;

        public RegionsController(
            NzWalksDbContext nzWalksDbContext,
            IRegionRepo regionRepo,
            IMapper mapper
        )
        {
            this._nzWalksDbContext = nzWalksDbContext;
            this._regionRepo = regionRepo;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            // get from db
            var regions = await _regionRepo.GetAllAsync();

            // domain to dto
            var regionsDto = _mapper.Map<List<RegionDto>>(regions);

            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var region = await _regionRepo.GetByIdAsync(id);

            if (region is null)
                return NotFound();

            // domain to DTO
            var regionDto = _mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion(RegionRequestDto newRegion)
        {
            if (ModelState.IsValid)
            {
                // dto to domain model
                var regionDomainModel = _mapper.Map<Region>(newRegion);

                // update db
                await _regionRepo.AddAsync(regionDomainModel);
                await _nzWalksDbContext.SaveChangesAsync();

                // domain model to DTO
                var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

                return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion(Guid id, UpdateAsyncRequestDto updatedRegion)
        {
            // DTO to domain model
            var update = _mapper.Map<Region>(updatedRegion);

            update = await _regionRepo.UpdateAsync(id, update);

            if (update is null)
                return NotFound();

            // domain model to DTO
            var regionDto = _mapper.Map<RegionDto>(update);

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var region = await _regionRepo.DeleteAsync(id);

            if (region is null)
                return NotFound();

            // domain to DT
            var regionDto = _mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }
    }
}
