namespace KariyerAgi.API.DTOs
{
    public class JobApplicationListDto
    {
        public int Id { get; set; }
        public DateTime AppliedAt { get; set; } = DateTime.Now;
        public string? Message { get; set; }
        public int Status { get; set; } // 0: Bekliyor, 1: Onay, 2: Red
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
    }
}
