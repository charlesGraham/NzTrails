using NzTrails.Api.Models.Domain;

namespace NzTrails.Api.Repositories.Interfaces
{
    public interface IWalkRepo
    {
        Task<Walk> AddAsync(Walk newWalk);
        Task<List<Walk>> GetAllAsync(
            string? filterOn = null,
            string? filterQuery = null,
            string? sortBy = null,
            bool isAscending = true,
            int pageNumber = 1,
            int pageSize = 1000
        );
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk?> UpdateAsync(Guid id, Walk updatedWalk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
