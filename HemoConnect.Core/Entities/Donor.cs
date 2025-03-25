using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Core.Entities
{
    public class Donor
    {
        public Donor(int id, string fullName, string email, DateTime birthDate, string gener, double weight, string bloodType, string rHFactor, List<Donation> donations, Address address)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gener = gener;
            Weight = weight;
            BloodType = bloodType;
            RHFactor = rHFactor;
            Donations = donations;
            Address = address;
        }

        public int Id { get; set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gener { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }
        public string RHFactor { get; private set; }
        public List<Donation> Donations { get; private set; }
        public Address Address { get; private set; }
    }
}
