using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Core.Entities
{
    public class Address
    {
        public Address() { }
        public Address(int id, string publicPlace, string city, string state, string postalCode, Donor donor)
        {
            Id = id;
            PublicPlace = publicPlace;
            City = city;
            State = state;
            PostalCode = postalCode;
            Donor = donor;
        }

        public int Id { get; private set; }
        public string PublicPlace { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public Donor Donor { get; private set; }
    }
}
