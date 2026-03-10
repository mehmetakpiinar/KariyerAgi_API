namespace KariyerAgi.API.DTOs
{
    namespace KariyerAgi.API.DTOs
    {
        // 1. ANA KURYE (Tüm profili taşıyacak)
        public class UserProfileDto
        {
            public int UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }

            // Alt listeler boş gelirse hata vermesin diye başlangıçta boş liste (instance) atıyoruz.
            public List<ProfileEducationDto> Educations { get; set; } = new List<ProfileEducationDto>();
            public List<ProfileExperienceDto> Experiences { get; set; } = new List<ProfileExperienceDto>();
            public List<ProfileSkillDto> Skills { get; set; } = new List<ProfileSkillDto>();
        }

        // 2. ALT KURYELER (Sadece ekranda görünecek bilgileri taşıyacaklar)
        public class ProfileEducationDto
        {
            public int Id { get; set; }
            public string SchoolName { get; set; }
            public string Department { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
        }

        public class ProfileExperienceDto
        {
            public int Id { get; set; }
            public string CompanyName { get; set; }
            public string Position { get; set; }
            public string Description { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
        }

        public class ProfileSkillDto
        {
            public int Id { get; set; }
            public string SkillName { get; set; }
        }
    }
}
