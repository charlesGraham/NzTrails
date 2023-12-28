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

        public RegionsController(NzWalksDbContext nzWalksDbContext, IRegionRepo regionRepo)
        {
            this._nzWalksDbContext = nzWalksDbContext;
            this._regionRepo = regionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            // get from db
            var regions = await _regionRepo.GetAllAsync();

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
            var region = await _regionRepo.GetByIdAsync(id);

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
            await _regionRepo.AddAsync(regionDomainModel);
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
        public async Task<IActionResult> UpdateRegion(Guid id, UpdateAsyncRequestDto updatedRegion)
        {
            // DTO to domain model
            var update = new Region
            {
                Code = updatedRegion.Code,
                Name = updatedRegion.Name,
                RegionImageUrl = updatedRegion.RegionImageUrl
            };

            update = await _regionRepo.UpdateAsync(id, update);

            if (update is null)
                return NotFound();

            // domain model to DTO
            var regionDto = new RegionDto()
            {
                Id = update.Id,
                Code = update.Code,
                Name = update.Name,
                RegionImageUrl = update.RegionImageUrl
            };

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            var region = await _regionRepo.DeleteAsync(id);

            if (region is null)
                return NotFound();

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
