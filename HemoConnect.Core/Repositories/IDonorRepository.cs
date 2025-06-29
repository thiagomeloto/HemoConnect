using HemoConnect.Core.Entities;

namespace HemoConnect.Core.Repositories
{
    public interface IDonorRepository
    {
        Task<int> AddAsync(Donor donor);
        Task<Donor> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
