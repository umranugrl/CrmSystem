using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Requests.Commands.Add;
using Application.Features.Requests.Commands.Delete;
using Application.Features.Requests.Commands.Update;
using Application.Features.Requests.Queries.GetAll;
using Application.Features.Requests.Queries.GetById;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddRequestCommand addRequestCommand)
        {
            var result = await _mediator.Send(addRequestCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRequestCommand updateRequestCommand)
        {
            var result = await _mediator.Send(updateRequestCommand);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleteRequestCommand = new DeleteRequestCommand { Id = id };
            var result = await _mediator.Send(deleteRequestCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllRequestQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var getRequestByIdQuery = new GetRequestByIdQuery { Id = id };
            var result = await _mediator.Send(getRequestByIdQuery);
            return Ok(result);
        }
    }
}