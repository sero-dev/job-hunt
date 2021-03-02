using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobRepository _jobs;

        public JobsController(IJobRepository jobs)
        {
            _jobs = jobs;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _jobs.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{JobId}")]
        public async Task<IActionResult> Get(string jobId)
        {
            Job job = await _jobs.GetAsync(jobId);
            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Job job)
        {
            await _jobs.AddAsync(job);
            return Created("", job);
        }
    }
}
