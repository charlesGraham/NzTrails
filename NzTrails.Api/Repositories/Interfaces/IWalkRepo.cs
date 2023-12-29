using NzTrails.Api.Models.Domain;
using NzTrails.Api.Models.DTO;

namespace NzTrails.Api.Repositories.Interfaces
{
    public interface IWalkRepo
    {
        Task<Walk> AddAsync(Walk newWalk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk?> UpdateAsync(Guid id, Walk updatedWalk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
