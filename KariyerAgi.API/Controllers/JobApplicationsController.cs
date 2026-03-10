using KariyerAgi.API.DTOs;
using KariyerAgi.DataAccess;
using KariyerAgi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (await _kariyerAgiContext.JobPosts.FindAsync(jobApplicationAddDto.JobPostId) == null)
            {
                return NotFound("Böyle bir iş ilanı sistemde bulunamadı.");
            }
            if (await _kariyerAgiContext.Users.FindAsync(jobApplicationAddDto.ApplicantId) == null)
            {
                return NotFound("Sistemde Kaydınız bulunamadı lütfen öncelikle giriş yapınız");
            }
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

        [HttpGet("GetByUserId/{userId}")]
        public async Task<IActionResult> GetJobApplication(int userId)
        {

           var applications = await _kariyerAgiContext.JobApplications.Where(u => u.ApplicantId == userId).Select(
                u => new JobApplicationListDto
                {
                    Id = u.Id,
                    AppliedAt = u.AppliedAt,
                    Message = u.Message,
                    Status = u.Status,
                    JobTitle = u.JobPost.Title,
                    CompanyName = u.JobPost.Company.Name,
                }).ToListAsync();
            return Ok(applications);
        }

        [HttpGet("GetByJobPostId/{jobPostId}")]
        public async Task<IActionResult> GetByJobPostId(int jobPostId)
        {
            var applications = await _kariyerAgiContext.JobApplications.Where(u => u.JobPostId == jobPostId).Select(
                u => new CompanyApplicationListDto
                {
                    Id = u.Id,
                    FirstName = u.Applicant.FirstName,
                    LastName = u.Applicant.LastName,
                    Message = u.Message,
                    CvPath = u.CvFilePath
                }).ToListAsync();
            return Ok(applications);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ApplicationStatusUpdateDto applicationStatusUpdateDto)
        {
            var jobApplication = await _kariyerAgiContext.JobApplications.FindAsync(id);
            if (jobApplication == null)
                return NotFound("Başvuru yok");
            jobApplication.Status = applicationStatusUpdateDto.Status;
            await _kariyerAgiContext.SaveChangesAsync();
            return Ok("Başvuru durumu başarıyla güncellendi.");
        }
    }
}
