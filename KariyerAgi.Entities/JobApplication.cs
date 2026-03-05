using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerAgi.Entities
{
    public class JobApplication
    {
        public int Id { get; set; }
        public DateTime AppliedAt { get; set; } = DateTime.Now;
        public string? Message { get; set; }
        public int Status { get; set; } // 0: Bekliyor, 1: Onay, 2: Red
        public string? CvFilePath { get; set; }

        // İlişki: Hangi ilana, kim başvurdu?
        public int JobPostId { get; set; }
        public JobPost JobPost { get; set; }

        public int ApplicantId { get; set; }
        public User Applicant { get; set; }
    }
}
