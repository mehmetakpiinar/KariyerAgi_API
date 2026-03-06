using KariyerAgi.Entities;

namespace KariyerAgi.API.DTOs
{
    public class JobPostDto
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public string WorkModel { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int CompanyId { get; set; }
    }
}
