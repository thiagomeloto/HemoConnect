using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Core.Entities
{
    public class Donation : BaseEntity
    {
        public Donation() { }
        public Donation(int donorId, DateTime donationDate, int amountML)
        {            
            DonorId = donorId;
            DonationDate = donationDate;
            AmountML = amountML;            
        }

        public int Id { get; private set; }
        public int DonorId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int AmountML { get; private set; }
        public Donor Donor { get; private set; }
    }
}
