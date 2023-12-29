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
            var walk = _mapper.Map<Walk>(newWalk); // DTO to domain
            await _walkRepo.AddAsync(walk);

            return Ok(_mapper.Map<WalkDto>(walk)); // domain to DTO
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walks = await _walkRepo.GetAllAsync();
            return Ok(_mapper.Map<List<WalkDto>>(walks)); // domain to DTO
        }
    }
}