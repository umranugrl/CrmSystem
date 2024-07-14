using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Opportunities.Commands.Add;
using Application.Features.Opportunities.Commands.Delete;
using Application.Features.Opportunities.Commands.Update;
using Application.Features.Opportunities.Queries.GetAll;
using Application.Features.Opportunities.Queries.GetById;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpportunitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OpportunitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddOpportunityCommand addOpportunityCommand)
        {
            var result = await _mediator.Send(addOpportunityCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOpportunityCommand updateOpportunityCommand)
        {
            var result = await _mediator.Send(updateOpportunityCommand);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleteOpportunityCommand = new DeleteOpportunityCommand { Id = id };
            var result = await _mediator.Send(deleteOpportunityCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllOpportunityQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var getOpportunityByIdQuery = new GetOpportunityByIdQuery { Id = id };
            var result = await _mediator.Send(getOpportunityByIdQuery);
            return Ok(result);
        }
    }
}