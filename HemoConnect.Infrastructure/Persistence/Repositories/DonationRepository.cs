using HemoConnect.Core.Entities;
using HemoConnect.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HemoConnect.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly HemoConnectDbContext _dbContext;
        public DonationRepository(HemoConnectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(Donation donation)
        {
            await _dbContext.Donation.AddAsync(donation);
            await _dbContext.SaveChangesAsync();

            return donation.Id;
        }

        public async Task<List<Donation>> GetAllDonationsAsync()
        {
            return await _dbContext.Donation.ToListAsync();
        }

        public async Task<List<Donation>> GetDonationByDonorIdAsync(int id)
        {
            var donations = await _dbContext.Donation.
                Where(d => d.DonorId == id).
                ToListAsync();

            return donations;
        }

        public async Task<Donation> GetDonationByIdAsync(int id)
        {
            var donation = await _dbContext.Donation.SingleOrDefaultAsync(d => d.Id == id);

            return donation;
        }
    }
}
