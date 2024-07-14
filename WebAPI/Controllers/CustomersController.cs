using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Customers.Commands.Add;
using Application.Features.Customers.Commands.Delete;
using Application.Features.Customers.Commands.Update;
using Application.Features.Customers.Queries.GetAll;
using Application.Features.Customers.Queries.GetById;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCustomerCommand addCustomerCommand)
        {
            var result = await _mediator.Send(addCustomerCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            var result = await _mediator.Send(updateCustomerCommand);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleteCustomerCommand = new DeleteCustomerCommand { Id = id };
            var result = await _mediator.Send(deleteCustomerCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCustomerQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var getCustomerByIdQuery = new GetCustomerByIdQuery { Id = id };
            var result = await _mediator.Send(getCustomerByIdQuery);
            return Ok(result);
        }
    }
}