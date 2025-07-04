using HemoConnect.Application.Commands.CreatDonor;
using HemoConnect.Application.Queries;
using HemoConnect.Application.Queries.GetDonationByDonorId;
using HemoConnect.Application.Queries.GetDonorById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HemoConnect.API.Controllers
{
    [ApiController]
    [Route("api/donor")]
    public class DonorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetDonorById(int id)
        {
            var donor = await _mediator.Send(new GetDonorByIdQuery { Id = id });

            if (donor != null)
                return Ok(donor);

            return NotFound();
        }

        [HttpGet("{id}/donations")]
        public async Task<IActionResult> GetDonationByDonorId(int id)
        {
            var donations = await _mediator.Send(new GetDonationByDonorIdQuery { Id = id });

            if (donations != null)
                return Ok(donations);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDonorCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var donorId = await _mediator.Send(command);

            if (donorId == 0)
                return BadRequest(new { error = "Já existe um doador com este e-mail."});

            if (donorId == -1)
                return BadRequest(new { error = "O doador deve ter no mínimo 50 kilos" });

            return CreatedAtAction(nameof(GetDonorById), new { id = donorId }, command);
        }
    }
}
