using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerAgi.Entities
{
    public enum UserRole
    {
        Admin = 0,       // Sistem Yöneticisi
        Student = 1,     // İş Arayan / Öğrenci
        Employer = 2     // İşveren
    }
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int UserTypeId { get; set; } // 1: Öğrenci, 2: İşveren

        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        public ICollection<Education> Educations { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
