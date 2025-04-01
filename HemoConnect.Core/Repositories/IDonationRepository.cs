using HemoConnect.Core.Entities;

namespace HemoConnect.Core.Repositories
{
    public interface IDonationRepository
    {
        Task<int> AddAsync(Donation donation);
        Task <List<Donation>> GetAllDonationsAsync();
    }
}
