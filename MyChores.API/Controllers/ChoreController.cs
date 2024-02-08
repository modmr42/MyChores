using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyChores.Application.Features.Chores.Commands;

namespace MyChores.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChoreController : ControllerBase
    {

        private readonly ILogger<ChoreController> _logger;
        private readonly IMediator _mediator;

        public ChoreController(ILogger<ChoreController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateChoreCommand command)
        {
            var createdEntityId = await _mediator.Send(command);
            return Ok(createdEntityId);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateChoreCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();

        }
    }
}
