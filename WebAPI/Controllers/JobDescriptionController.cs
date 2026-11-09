using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobDescriptionController : ControllerBase
    {
        private readonly IJobDescriptionService _jobDescriptionService;

        public JobDescriptionController(IJobDescriptionService jobDescriptionService)
        {
            _jobDescriptionService = jobDescriptionService;
        }

        [HttpPost("add")]
        public IActionResult Add(JobDescription jobDescription)
        {
            var result = _jobDescriptionService.Add(jobDescription);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(JobDescription jobDescription)
        {
            var result = _jobDescriptionService.Delete(jobDescription);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(JobDescription jobDescription)
        {
            var result = _jobDescriptionService.Update(jobDescription);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

