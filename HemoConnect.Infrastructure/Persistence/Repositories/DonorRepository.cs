using HemoConnect.Core.Entities;
using HemoConnect.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Infrastructure.Persistence.Repositories
{
    public class DonorRepository : IDonorReposiory
    {
        public Task<int> AddAsync(Donor donor)
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
