using Application.Features.Interactions.Commands.Add;
using Application.Features.Interactions.Commands.Delete;
using Application.Features.Interactions.Commands.Update;
using Application.Features.Interactions.Queries.GetAll;
using Application.Features.Interactions.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InteractionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddInteractionCommand addInteractionCommand)
        {
            var result = await _mediator.Send(addInteractionCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateInteractionCommand updateInteractionCommand)
        {
            var result = await _mediator.Send(updateInteractionCommand);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleteInteractionCommand = new DeleteInteractionCommand { Id = id };
            var result = await _mediator.Send(deleteInteractionCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllInteractionQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var getInteractionByIdQuery = new GetInteractionByIdQuery { Id = id };
            var result = await _mediator.Send(getInteractionByIdQuery);
            return Ok(result);
        }
    }
}