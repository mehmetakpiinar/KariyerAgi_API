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
    public class JobPostsController : ControllerBase
    {
        readonly private KariyerAgiContext _kariyerAgiContext;
        public JobPostsController(KariyerAgiContext kariyerAgiContext)
        {
            _kariyerAgiContext = kariyerAgiContext;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> JobPostAdd(JobPostDto jobPostDto)
        {
            var newJobPost = new JobPost
            {
                Title = jobPostDto.Title,
                Location = jobPostDto.Location,
                WorkModel = jobPostDto.WorkModel,
                Description = jobPostDto.Description,
                Deadline = jobPostDto.Deadline,
                CompanyId = jobPostDto.CompanyId,
                CreatedAt = DateTime.Now
            };
            await _kariyerAgiContext.JobPosts.AddAsync(newJobPost);
            await _kariyerAgiContext.SaveChangesAsync();
            return Ok("İş ilanı başarıyla eklendi!");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var jobPosts = await _kariyerAgiContext.JobPosts
                .Select(j => new JobPostListDto
                {
                    Id = j.Id,
                    Title = j.Title,
                    CompanyName = j.Company.Name,
                    Location = j.Location,
                    WorkModel = j.WorkModel,
                    CreatedAt = DateTime.Now

                })
                .ToListAsync(); // Asenkron olarak listeye çevir

            return Ok(jobPosts);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] JobPostDto jobPostDto)
        {
            var jobPost = await _kariyerAgiContext.JobPosts.FindAsync(id);

            if (jobPost == null)
            {
                return NotFound("Güncellenecek iş ilanı bulunamadı.");
            }

            jobPost.Location = jobPostDto.Location;
            jobPost.Title = jobPostDto.Title;
            jobPost.Description = jobPostDto.Description;
            jobPost.WorkModel = jobPostDto.WorkModel;
            jobPost.Deadline = jobPostDto.Deadline;

            await _kariyerAgiContext.SaveChangesAsync();
            return Ok("İş ilanı başarıyla güncellendi!");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var jobPost = await _kariyerAgiContext.JobPosts.FindAsync(id);
            if (jobPost == null)
                return NotFound("Silinecek iş ilanı bulunamadı.");
            _kariyerAgiContext.JobPosts.Remove(jobPost);
            await _kariyerAgiContext.SaveChangesAsync();
            return Ok("Başarıyla Silindi.");
        }
    }
}
