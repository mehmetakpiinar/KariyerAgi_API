namespace KariyerAgi.API.DTOs
{

    public class JobPostListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string WorkModel { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
