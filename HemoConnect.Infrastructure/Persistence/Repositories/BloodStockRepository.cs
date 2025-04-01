using HemoConnect.Core.Entities;
using HemoConnect.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HemoConnect.Infrastructure.Persistence.Repositories
{
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly HemoConnectDbContext _dbContext;
        public BloodStockRepository(HemoConnectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BloodStock>> GetAllBloodStockAsync()
        {
            return await _dbContext.BloodStocks.ToListAsync();
        }
    }
}
