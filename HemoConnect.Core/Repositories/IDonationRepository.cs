using HemoConnect.Core.Entities;

namespace HemoConnect.Core.Repositories
{
    public interface IDonationRepository
    {
        Task<int> AddAsync(Donation donation);
        Task <List<Donation>> GetAllDonationsAsync();
        Task<Donation> GetDonationByIdAsync(int id);
        Task<List<Donation>> GetDonationByDonorIdAsync(int id);
    }
}
