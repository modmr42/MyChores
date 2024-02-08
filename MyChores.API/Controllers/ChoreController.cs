using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyChores.Application.Features.Chores.Commands;
using MyChores.Application.Features.Chores.Queries;

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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var dto = await _mediator.Send(new GetChoreByIdQuery { Id = id });

            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dto = await _mediator.Send(new GetChoresQuery());

            return Ok(dto);
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

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteChoreCommand { Id = id });
            return NoContent();
        }
    }
}
