using System;
using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllJobsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{jobId}")]
        public async Task<IActionResult> Get(Guid jobId)
        {
            var query = new GetJobByIdQuery(jobId);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateJobRequest newJobRequest)
        {
            var command = new CreateJobCommand(newJobRequest);
            var result = await _mediator.Send(command);
            return result != null ? Created("", result) : UnprocessableEntity();
        }
    }
}
