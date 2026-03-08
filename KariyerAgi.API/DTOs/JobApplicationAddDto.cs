using KariyerAgi.Entities;

namespace KariyerAgi.API.DTOs
{
    public class JobApplicationAddDto
    {
        public string? Message { get; set; }
        public string? CvFilePath { get; set; }
        public int JobPostId { get; set; }
        public int ApplicantId { get; set; }

    }
}
