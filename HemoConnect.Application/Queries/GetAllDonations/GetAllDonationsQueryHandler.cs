using HemoConnect.Core.Entities;
using HemoConnect.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Application.Queries.GetAllDonations
{
    public class GetAllDonationsQueryHandler : IRequestHandler<GetAllDonationsQuery, List<Donation>>
    {
        private readonly IDonationRepository _donationRepository;

        public GetAllDonationsQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<List<Donation>> Handle(GetAllDonationsQuery request, CancellationToken cancellationToken)
        {
            return await _donationRepository.GetAllDonationsAsync();
        }
    }
}
