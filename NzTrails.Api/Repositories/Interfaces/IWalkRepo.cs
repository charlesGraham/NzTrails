using NzTrails.Api.Models.Domain;

namespace NzTrails.Api.Repositories.Interfaces
{
    public interface IWalkRepo
    {
        Task<Walk> AddAsync(Walk newWalk);
    }
}
