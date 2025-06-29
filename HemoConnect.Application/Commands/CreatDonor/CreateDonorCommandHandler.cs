using HemoConnect.Core.Entities;
using HemoConnect.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Application.Commands.CreatDonor
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, int>
    {
        private readonly IDonorRepository _donorRepository;

        public CreateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<int> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = new Donor(
                request.FullName, 
                request.Email, 
                request.BirthDate, 
                request.Gener, 
                request.Weight, 
                request.BloodType, 
                request.RHFactor
            );

            //var address = new Address(
            //    request.Address.PublicPlace, 
            //    request.Address.City, 
            //    request.Address.State, 
            //    request.Address.PostalCode, 
            //    donor
            //);

            return await _donorRepository.AddAsync(donor);
        }
    }
}
