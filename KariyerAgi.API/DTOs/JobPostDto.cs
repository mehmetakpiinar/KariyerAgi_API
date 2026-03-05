using KariyerAgi.Entities;

namespace KariyerAgi.API.DTOs
{
    public class JobPostDto
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public string WorkModel { get; set; } // Uzaktan, Hibrit vs.
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int CompanyId { get; set; }
    }
}
