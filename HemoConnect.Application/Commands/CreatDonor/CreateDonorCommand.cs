using HemoConnect.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Application.Commands.CreatDonor
{
    public class CreateDonorCommand : IRequest<int>
    {
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
