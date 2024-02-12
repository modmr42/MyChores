using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyChores.API.Mappers;
using MyChores.Application.Features.Chores.Commands;
using MyChores.Application.Features.Chores.Queries;
using System.Security.Claims;

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
            var query = new GetChoreByIdForUserQuery { Id = id };

            query.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var dto = await _mediator.Send(query);

            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetChoresForUserQuery();

            query.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var dto = await _mediator.Send(query);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateChoreCommand command)
        {
            var comm = (CreateChoreForUserCommand)command;
            comm.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var createdEntityId = await _mediator.Send(comm);
            return Ok(createdEntityId);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateChoreCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var comm = (UpdateChoreForUserCommand)command;
            comm.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _mediator.Send(comm);

            return NoContent();

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var comm = new DeleteChoreForUserCommand { Id = id };

            comm.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _mediator.Send(comm);
            return NoContent();
        }
    }
}
