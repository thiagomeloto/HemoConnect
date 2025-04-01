using HemoConnect.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Core.Repositories
{
    public interface IBloodStockRepository
    {
        Task<BloodStock> GetAllBloodStockAsync();
    }
}
