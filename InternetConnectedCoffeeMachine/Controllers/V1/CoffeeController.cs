using InternetConnectedCoffeeMachine.Application.Infrastracture.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InternetConnectedCoffeeMachine.Controllers.V1
{
    [ApiController]
    [Route("brew-coffee")]
    public class CoffeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoffeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCoffeeQuery(), cancellationToken);
            if (result.IsSuccessful)
            {
                return Ok(result.Data);
            }
            if (result.StatusCode == StatusCodes.Status503ServiceUnavailable)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, null);
            }
            if (result.StatusCode == StatusCodes.Status418ImATeapot)
            {
                return StatusCode(StatusCodes.Status418ImATeapot, null);
            }

            return NotFound();

        }
    }
}
