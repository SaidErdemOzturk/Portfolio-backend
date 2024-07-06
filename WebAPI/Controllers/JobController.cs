using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost("add")]
        public IActionResult Add(Job job)
        {

            var result = _jobService.Add(job);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Job job)
        {
            var result = _jobService.Delete(job);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Job job)
        {
            var result = _jobService.Update(job);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getjobwithdescriptiondto")]
        public IActionResult GetWithDescriptionDto()
        {
            var result = _jobService.GetJobsWithDescriptionDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
