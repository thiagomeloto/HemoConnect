using HemoConnect.Application.DTO;
using HemoConnect.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Application.Queries.GetDonationByDonorId
{
    public class GetDonationByDonorIdQuery : IRequest<List<DonationDTO>>
    {
        public int Id { get; set; }
    }
}
