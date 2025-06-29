using HemoConnect.Application.Queries.GetDonorById;
using HemoConnect.Core.Entities;
using HemoConnect.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Application.Queries.GetDonationById
{
    public class GetDonationByIdQueryHandler : IRequestHandler<GetDonationByIdQuery, Donation>
    {
        private readonly IDonationRepository _donationRepository;

        public GetDonationByIdQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }
        public async Task<Donation> Handle(GetDonationByIdQuery request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepository.GetDonationByIdAsync(request.Id);

            return donation;
        }
    }
}
