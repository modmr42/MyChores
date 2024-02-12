using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyChores.Application.Features.Auth.Commands;
using MyChores.Application.Features.Auth.Queries;

namespace MyChores.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;

        public AuthController(ILogger<AuthController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var createdEntityId = await _mediator.Send(command);

            return Ok(createdEntityId);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserQuery query)
        {
            var response = await _mediator.Send(query);

            if(response == null)
                return Unauthorized();

            return Ok(response);
        }


        //[HttpPut("{id:guid}")]
        //public async Task<IActionResult> Update(Guid id, UpdateChoreCommand command)
        //{
        //    if (id != command.Id)
        //        return BadRequest();

        //    var comm = (UpdateChoreForUserCommand)command;
        //    comm.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    await _mediator.Send(comm);

        //    return NoContent();

        //}

        //[HttpDelete("{id:guid}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var comm = new DeleteChoreForUserCommand { Id = id };

        //    comm.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    await _mediator.Send(comm);
        //    return NoContent();
        //}
    }
}
