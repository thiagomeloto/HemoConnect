using HemoConnect.Application.Commands.CreateDonation;
using HemoConnect.Application.Queries.GetAllBloodStock;
using HemoConnect.Application.Queries.GetDonationByDonorId;
using HemoConnect.Application.Queries.GetDonationById;
using HemoConnect.Application.Queries.GetDonorById;
using HemoConnect.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HemoConnect.API.Controllers
{
    [ApiController]
    [Route("api/donation")]
    public class DonationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetDonationById(int id)
        {
            var donation = await _mediator.Send(new GetDonationByIdQuery { Id = id });

            if (donation != null)
                return Ok(donation);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDonationCommand command)
        {
            var donationId = await _mediator.Send(command);

            if (donationId == null)
                return NotFound(new { error = "Doador não encontrado." });

            if (donationId == -1)
                return BadRequest(new { error = "O doador deve ter no mínimo 18 anos para realizar uma doação." });

            return CreatedAtAction(nameof(GetDonationById), new { id = donationId }, command);
        }

        [HttpGet("bloodstock")]
        public async Task<IActionResult> GetAllBloodStock()
        {
            var allBloodStock = await _mediator.Send(new GetAllBloodStockQuery());

            return Ok(allBloodStock);
        }
    }
}
