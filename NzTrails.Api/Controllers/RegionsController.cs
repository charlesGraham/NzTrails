using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            // get from db
            var regions = _nzWalksDbContext.Regions.ToList();

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
        public IActionResult GetRegionById(Guid id)
        {
            var region = _nzWalksDbContext.Regions.Find(id);

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
        public IActionResult AddRegion(RegionRequestDto newRegion)
        {
            //convert request dto to domain model
            var regionDomainModel = new Region()
            {
                Code = newRegion.Code,
                Name = newRegion.Name,
                RegionImageUrl = newRegion.RegionImageUrl
            };

            // update db
            _nzWalksDbContext.Regions.Add(regionDomainModel);
            _nzWalksDbContext.SaveChanges();

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
        public IActionResult UpdateRegion(Guid id, UpdateRegionRequestDto updatedRegion)
        {
            var regionDomainModel = _nzWalksDbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomainModel is null)
                return NotFound();

            // DTO to domain model
            regionDomainModel.Code = updatedRegion.Code;
            regionDomainModel.Name = updatedRegion.Name;
            regionDomainModel.RegionImageUrl = updatedRegion.RegionImageUrl;

            _nzWalksDbContext.SaveChanges();

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
        public IActionResult DeleteRegion(Guid id)
        {
            var region = _nzWalksDbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (region is null)
                return NotFound();

            _nzWalksDbContext.Regions.Remove(region);
            _nzWalksDbContext.SaveChanges();

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
