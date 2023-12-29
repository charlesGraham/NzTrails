using Microsoft.EntityFrameworkCore;
using NzTrails.Api.Data;
using NzTrails.Api.Models.Domain;
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

        public async Task<List<Walk>> GetAllAsync()
        {
            return await _dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _dbContext
                .Walks.Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
