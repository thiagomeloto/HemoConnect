using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Core.Entities
{
    public class BloodStock
    {
        public BloodStock(int id, string bloodType, string rHFactor, int amountML)
        {
            Id = id;
            BloodType = bloodType;
            RHFactor = rHFactor;
            AmountML = amountML;
        }

        public int Id { get; private set; }
        public string BloodType { get; private set; }
        public string RHFactor { get; private set; }
        public int AmountML { get; private set; }
    }
}
