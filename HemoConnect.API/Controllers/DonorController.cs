using HemoConnect.Application.Commands;
using HemoConnect.Application.Queries;
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
            var donor = await _mediator.Send(new GetDonorByIdQuery { Id = id});

            return Ok(donor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDonorCommand command)
        {
            var donorId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetDonorById), new { id = donorId }, command);
        }
    }
}
