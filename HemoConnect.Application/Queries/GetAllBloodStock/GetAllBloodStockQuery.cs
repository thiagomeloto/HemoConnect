using HemoConnect.Core.Entities;
using MediatR;

namespace HemoConnect.Application.Queries.GetAllBloodStock
{
    public class GetAllBloodStockQuery : IRequest<List<BloodStock>>
    {
    }
}
