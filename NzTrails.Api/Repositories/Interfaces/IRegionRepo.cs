using NzTrails.Api.Models.Domain;

namespace NzTrails.Api.Repositories.Interfaces
{
    public interface IRegionRepo
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> AddAsync(Region newRegion);
        Task<Region?> UpdateAsync(Guid id, Region updatedRegion);
        Task<Region?> DeleteAsync(Guid id);
    }
}
