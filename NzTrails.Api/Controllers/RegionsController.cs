using Microsoft.AspNetCore.Mvc;
using NzTrails.Api.Models.Domain;

namespace NzTrails.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland Region",
                    Code = "AKL",
                    RegionImageUrl =
                        "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Wellington Region",
                    Code = "WLG",
                    RegionImageUrl =
                        "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg"
                }
            };

            return Ok(regions);
        }
    }
}
