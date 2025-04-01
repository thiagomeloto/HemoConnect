using HemoConnect.Core.Entities;

namespace HemoConnect.Core.Repositories
{
    public interface IDonorReposiory
    {
        Task<int> AddAsync(Donor donor);
        Task<Donor> GetByIdAsync(int id);
    }
}
