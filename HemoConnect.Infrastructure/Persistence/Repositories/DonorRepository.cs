using HemoConnect.Core.Entities;
using HemoConnect.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : IDonorReposiory
    {
        private readonly HemoConnectDbContext _dbContext;
        public DonorRepository(HemoConnectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(Donor donor)
        {
            await _dbContext.Donors.AddAsync(donor);
            await _dbContext.SaveChangesAsync();

            return donor.Id;
        }

        public async Task<Donor> GetByIdAsync(int id)
        {
            var donor = await _dbContext.Donors.SingleOrDefaultAsync(d => d.Id == id);

            return donor;
        }
    }
}
