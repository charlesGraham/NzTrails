using NzTrails.Api.Models.Domain;

namespace NzTrails.Api.Repositories.Interfaces
{
    public interface IWalkRepo
    {
        Task<Walk> AddAsync(Walk newWalk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id);
    }
}
