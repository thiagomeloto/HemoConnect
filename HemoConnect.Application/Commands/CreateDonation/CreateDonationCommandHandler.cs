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

            var validateAge = CalculateAge(donor.BirthDate);

            if (validateAge < 18)
                return -1;

            var validateAmountML = ValidateAmountML(request.AmountML);

            if(!validateAmountML)
                return -2;

            var donation = new Donation(request.DonorId, request.DonationDate, request.AmountML);
            await _donationRepository.AddAsync(donation);

            var bloodStock = new BloodStock(donor.BloodType, donor.RHFactor, request.AmountML);
            await _bloodStockRepository.AddBloodStockAsync(bloodStock);

            return donation.Id;
        }

        public int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age)) 
                age--;

            return age;
        }

        public bool ValidateAmountML(int amountML)
        {
            if (amountML >= 420 && amountML <= 470)
                return true;

            return false;
        }
    }
}
