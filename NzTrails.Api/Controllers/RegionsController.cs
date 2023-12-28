using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NzTrails.Api.Data;
using NzTrails.Api.Models.Domain;
using NzTrails.Api.Models.DTO;

namespace NzTrails.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly NzWalksDbContext _nzWalksDbContext;

        public RegionsController(NzWalksDbContext nzWalksDbContext)
        {
            this._nzWalksDbContext = nzWalksDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            // get from db
            var regions = await _nzWalksDbContext.Regions.ToListAsync();

            // domain model to DTO
            var regionsDto = new List<RegionDto>();
            foreach (var region in regions)
            {
                regionsDto.Add(
                    new RegionDto()
                    {
                        Id = region.Id,
                        Name = region.Name,
                        Code = region.Code,
                        RegionImageUrl = region.RegionImageUrl
                    }
                );
            }

            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var region = await _nzWalksDbContext.Regions.FindAsync(id);

            if (region is null)
                return NotFound();

            var regionDto = new RegionDto()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion(RegionRequestDto newRegion)
        {
            //convert request dto to domain model
            var regionDomainModel = new Region()
            {
                Code = newRegion.Code,
                Name = newRegion.Name,
                RegionImageUrl = newRegion.RegionImageUrl
            };

            // update db
            await _nzWalksDbContext.Regions.AddAsync(regionDomainModel);
            await _nzWalksDbContext.SaveChangesAsync();

            // domain model to DTO
            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion(Guid id, UpdateRegionRequestDto updatedRegion)
        {
            var regionDomainModel = await _nzWalksDbContext.Regions.FirstOrDefaultAsync(
                x => x.Id == id
            );

            if (regionDomainModel is null)
                return NotFound();

            // DTO to domain model
            regionDomainModel.Code = updatedRegion.Code;
            regionDomainModel.Name = updatedRegion.Name;
            regionDomainModel.RegionImageUrl = updatedRegion.RegionImageUrl;

            await _nzWalksDbContext.SaveChangesAsync();

            // domain model to DTO
            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var region = await _nzWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region is null)
                return NotFound();

            _nzWalksDbContext.Regions.Remove(region);
            await _nzWalksDbContext.SaveChangesAsync();

            // domain to DTO
            var regionDto = new RegionDto()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDto);
        }
    }
}
