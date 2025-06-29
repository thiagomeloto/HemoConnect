using HemoConnect.Application.DTO;
using HemoConnect.Application.Queries.GetDonationById;
using HemoConnect.Core.Entities;
using HemoConnect.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Application.Queries.GetDonationByDonorId
{
    public class GetDonationByDonorIdQueryHandler : IRequestHandler<GetDonationByDonorIdQuery, List<DonationDTO>>
    {
        private readonly IDonationRepository _donationRepository;

        public GetDonationByDonorIdQueryHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<List<DonationDTO>> Handle(GetDonationByDonorIdQuery request, CancellationToken cancellationToken)
        {
            var donations = await _donationRepository.GetDonationByDonorIdAsync(request.Id);

            return donations.Select(d => new DonationDTO
            {
                Id = d.Id,
                DonorId = d.DonorId,
                DonationDate = d.DonationDate,
                AmountML = d.AmountML
            }).ToList();
        }
    }
}
