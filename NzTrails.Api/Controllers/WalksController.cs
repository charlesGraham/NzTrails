using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NzTrails.Api.Models.Domain;
using NzTrails.Api.Models.DTO;
using NzTrails.Api.Repositories.Interfaces;

namespace NzTrails.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepo _walkRepo;

        public WalksController(IMapper mapper, IWalkRepo walkRepo)
        {
            this._walkRepo = walkRepo;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddWalk(AddWalkRequestDto newWalk)
        {
            // DTO to domain
            var walk = _mapper.Map<Walk>(newWalk);

            await _walkRepo.AddAsync(walk);

            // domain to DTO
            var walkDto = _mapper.Map<WalkDto>(walk);

            return Ok(walkDto);
        }
    }
}
