using Microsoft.EntityFrameworkCore;
using NzTrails.Api.Data;
using NzTrails.Api.Models.Domain;
using NzTrails.Api.Models.DTO;
using NzTrails.Api.Repositories.Interfaces;

namespace NzTrails.Api.Repositories.Implementation
{
    public class WalkRepo : IWalkRepo
    {
        private readonly NzWalksDbContext _dbContext;

        public WalkRepo(NzWalksDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Walk> AddAsync(Walk newWalk)
        {
            await _dbContext.Walks.AddAsync(newWalk);
            await _dbContext.SaveChangesAsync();
            return newWalk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk is null)
                return null;

            _dbContext.Walks.Remove(existingWalk);
            await _dbContext.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(
            string? filterOn = null,
            string? filterQuery = null,
            string? sortBy = null,
            bool isAscending = true
        )
        {
            var walks = _dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();

            // filtering
            if (
                string.IsNullOrWhiteSpace(filterOn) == false
                && string.IsNullOrWhiteSpace(filterQuery) == false
            )
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            // sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending
                        ? walks.OrderBy(x => x.Name)
                        : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending
                        ? walks.OrderBy(x => x.LengthInKm)
                        : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            return await walks.ToListAsync();

            // return await _dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _dbContext
                .Walks.Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk updatedWalk)
        {
            var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk is null)
                return null;

            existingWalk.Name = updatedWalk.Name;
            existingWalk.Description = updatedWalk.Description;
            existingWalk.LengthInKm = updatedWalk.LengthInKm;
            existingWalk.WalkImageUrl = updatedWalk.WalkImageUrl;
            existingWalk.DifficultyId = updatedWalk.DifficultyId;
            existingWalk.RegionId = updatedWalk.RegionId;
            existingWalk.Difficulty = updatedWalk.Difficulty;
            existingWalk.Region = updatedWalk.Region;

            await _dbContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}
