namespace KariyerAgi.API.DTOs
{
    public class EducationAddDto
    {
        public string schoolName { get; set; }
        public string Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int UserId { get; set; }
    }
}
