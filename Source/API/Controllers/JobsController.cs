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

        /// <summary>
        /// Retrieves all jobs saved
        /// </summary>
        /// <returns>A ListResponse object of type Job</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllJobsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves the specified job by using its ID. Returns NotFound if job cannot be found
        /// </summary>
        /// <param name="jobId">The ID of the Job</param>
        /// <returns>The specified job if found. NotFound if the job cannot be found</returns>
        [HttpGet("{jobId}")]
        public async Task<IActionResult> Get(Guid jobId)
        {
            var query = new GetJobByIdQuery(jobId);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }
        
        /// <summary>
        /// Creates a new job based on the CreateJobRequest in the body of the request
        /// </summary>
        /// <param name="newJobRequest">The new job information</param>
        /// <returns>The ID for the newly created job. If job cannot be created, returns UnprocessableEntity</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateJobRequest newJobRequest)
        {
            var command = new CreateJobCommand(newJobRequest);
            var result = await _mediator.Send(command);
            return result != null ? Created("", result) : UnprocessableEntity();
        }
    }
}
