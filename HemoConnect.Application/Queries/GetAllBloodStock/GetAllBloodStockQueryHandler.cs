using HemoConnect.Core.Entities;
using HemoConnect.Core.Repositories;
using MediatR;

namespace HemoConnect.Application.Queries.GetAllBloodStock
{
    public class GetAllBloodStockQueryHandler : IRequestHandler<GetAllBloodStockQuery, List<BloodStock>>
    {
        private readonly IBloodStockRepository _bloodStockRepository;

        public GetAllBloodStockQueryHandler(IBloodStockRepository bloodStockRepository)
        {
            _bloodStockRepository = bloodStockRepository;
        }
        public async Task<List<BloodStock>> Handle(GetAllBloodStockQuery request, CancellationToken cancellationToken)
        {
            return await _bloodStockRepository.GetAllBloodStockAsync();
        }
    }
}
