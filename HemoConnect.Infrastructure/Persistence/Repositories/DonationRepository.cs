using HemoConnect.Core.Entities;
using HemoConnect.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        public Task<int> AddAsync(Donation donation)
        {
            throw new NotImplementedException();
        }

        public Task<List<Donation>> GetAllDonationsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
