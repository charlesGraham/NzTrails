using Microsoft.EntityFrameworkCore;
using NzTrails.Api.Data;
using NzTrails.Api.Models.Domain;
using NzTrails.Api.Repositories.Interfaces;

namespace NzTrails.Api.Repositories.Implementation
{
    public class RegionRepo : IRegionRepo
    {
        private readonly NzWalksDbContext _dbContext;

        public RegionRepo(NzWalksDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Region> AddAsync(Region newRegion)
        {
            await _dbContext.Regions.AddAsync(newRegion);
            await _dbContext.SaveChangesAsync();
            return newRegion;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion is null)
                return null;

            _dbContext.Regions.Remove(existingRegion);
            await _dbContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Regions.FindAsync(id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region updatedRegion)
        {
            var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion is null)
                return null;

            existingRegion.Code = updatedRegion.Code;
            existingRegion.Name = updatedRegion.Name;
            existingRegion.RegionImageUrl = updatedRegion.RegionImageUrl;
            await _dbContext.SaveChangesAsync();

            return existingRegion;
        }
    }
}
