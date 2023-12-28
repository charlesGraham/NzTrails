using Microsoft.AspNetCore.Mvc;
using NzTrails.Api.Data;
using NzTrails.Api.Models.Domain;

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
            var regions = _nzWalksDbContext.Regions.ToList();
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetRegionById(Guid id)
        {
            var region = _nzWalksDbContext.Regions.Find(id);

            if (region is null)
            {
                return NotFound();
            }

            return Ok(region);
        }
    }
}
