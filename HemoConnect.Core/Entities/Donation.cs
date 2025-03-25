using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Core.Entities
{
    public class Donation
    {
        public Donation(int id, int donorId, DateTime donationDate, int amountML, Donor donor)
        {
            Id = id;
            DonorId = donorId;
            DonationDate = donationDate;
            AmountML = amountML;
            Donor = donor;
        }

        public int Id { get; private set; }
        public int DonorId { get; private set; }
        public DateTime DonationDate { get; private set; }
        public int AmountML { get; private set; }
        public Donor Donor { get; private set; }
    }
}
