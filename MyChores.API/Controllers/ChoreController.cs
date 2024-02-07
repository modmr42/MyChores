using Microsoft.AspNetCore.Mvc;
using MyChores.Application.Features.Chores.Commands;

namespace MyChores.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChoreController : ControllerBase
    {

        private readonly ILogger<ChoreController> _logger;
        private readonly IMedatior _mediator;

        public ChoreController(ILogger<ChoreController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateChoreCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
