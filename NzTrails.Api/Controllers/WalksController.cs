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
        public async Task<IActionResult> GetAllWalks(
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending
        )
        {
            var walks = await _walkRepo.GetAllAsync(
                filterOn,
                filterQuery,
                sortBy,
                isAscending ?? true
            );
            return Ok(_mapper.Map<List<WalkDto>>(walks)); // domain to DTO
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalkById(Guid id)
        {
            var walk = await _walkRepo.GetByIdAsync(id); // is domain model
            if (walk is null)
                return NotFound();

            return Ok(_mapper.Map<WalkDto>(walk));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateWalk(Guid id, UpdateWalkRequestDto updatedWalk)
        {
            var update = _mapper.Map<Walk>(updatedWalk); // DTO to domain

            update = await _walkRepo.UpdateAsync(id, update);
            if (update is null)
                return NotFound();

            return Ok(_mapper.Map<WalkDto>(update)); // domain to DTO
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteWalk(Guid id)
        {
            var walk = await _walkRepo.DeleteAsync(id);
            if (walk is null)
                return NotFound();

            return Ok(_mapper.Map<WalkDto>(walk));
        }
    }
}
