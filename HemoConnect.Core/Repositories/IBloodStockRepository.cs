using HemoConnect.Core.Entities;

namespace HemoConnect.Core.Repositories
{
    public interface IBloodStockRepository
    {
        Task<List<BloodStock>> GetAllBloodStockAsync();
    }
}
