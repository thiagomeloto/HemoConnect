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
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gener { get; set; }
        public double Weight { get; set; }
        public string BloodType { get; set; }
        public string RHFactor { get; set; }     
    }
}
