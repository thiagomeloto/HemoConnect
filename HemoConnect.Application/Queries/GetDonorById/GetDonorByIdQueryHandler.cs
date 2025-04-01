using HemoConnect.Core.Entities;
using HemoConnect.Core.Repositories;
using MediatR;
using System.Runtime.CompilerServices;

namespace HemoConnect.Application.Queries.GetDonorById
{
    public class GetDonorByIdQueryHandler : IRequestHandler<GetDonorByIdQuery, Donor>
    {
        private readonly IDonorReposiory _donorReposiory;

        public GetDonorByIdQueryHandler(IDonorReposiory donorReposiory)
        {
            _donorReposiory = donorReposiory;
        }

        public async Task<Donor> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _donorReposiory.GetByIdAsync(request.Id);

            return donor;
        }
    }
}
