using HemoConnect.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Application.Queries.GetDonorById
{
    public class GetDonorByIdQuery : IRequest<Donor>
    {
        public int Id { get; set; }
    }
}
