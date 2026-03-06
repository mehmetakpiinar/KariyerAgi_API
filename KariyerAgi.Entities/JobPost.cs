using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerAgi.Entities
{
    public class JobPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string WorkModel { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
