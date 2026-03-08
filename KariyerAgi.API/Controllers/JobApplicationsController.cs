using KariyerAgi.API.DTOs;
using KariyerAgi.DataAccess;
using KariyerAgi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KariyerAgi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        readonly private KariyerAgiContext _kariyerAgiContext;
        public JobApplicationsController(KariyerAgiContext kariyerAgiContext)
        {
            _kariyerAgiContext = kariyerAgiContext;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> JobAddApplication([FromBody] JobApplicationAddDto jobApplicationAddDto)
        {
            var jobApplication = new JobApplication
            {
                AppliedAt = DateTime.UtcNow,
                Message = jobApplicationAddDto.Message,
                Status = 0,
                CvFilePath = jobApplicationAddDto.CvFilePath,
                JobPostId = jobApplicationAddDto.JobPostId,
                ApplicantId = jobApplicationAddDto.ApplicantId,

            };
            await _kariyerAgiContext.JobApplications.AddAsync(jobApplication);
            await _kariyerAgiContext.SaveChangesAsync();
            return Ok("Başvuru başarıyla gerçekleşti");
        }
    }
}
