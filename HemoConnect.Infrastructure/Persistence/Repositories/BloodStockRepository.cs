using HemoConnect.Core.Entities;
using HemoConnect.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Infrastructure.Persistence.Repositories
{
    public class BloodStockRepository : IBloodStockRepository
    {
        public Task<BloodStock> GetAllBloodStockAsync()
        {
            throw new NotImplementedException();
        }
    }
}
