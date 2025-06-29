using HemoConnect.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Application.Queries.GetDonationById
{
    public class GetDonationByIdQuery : IRequest<Donation>
    {
        public int Id { get; set; }
    }
}
