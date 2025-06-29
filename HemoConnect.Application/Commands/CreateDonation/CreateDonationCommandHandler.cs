using HemoConnect.Core.Entities;
using HemoConnect.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Application.Commands.CreateDonation
{
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, int?>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IDonorRepository _donorRepository;
        private readonly IBloodStockRepository _bloodStockRepository;
        public CreateDonationCommandHandler(IDonationRepository donationRepository, IDonorRepository donorRepository, IBloodStockRepository bloodStockRepository)
        {
            _donationRepository = donationRepository;
            _donorRepository = donorRepository;
            _bloodStockRepository = bloodStockRepository;
        }
        public async Task<int?> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetByIdAsync(request.DonorId);

            if (donor == null)
                return null;

            var donation = new Donation(request.DonorId, request.DonationDate, request.AmountML);
            await _donationRepository.AddAsync(donation);

            var bloodStock = new BloodStock(donor.BloodType, donor.RHFactor, request.AmountML);
            await _bloodStockRepository.AddBloodStockAsync(bloodStock);

            return donation.Id;
        }
    }
}
