using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerAgi.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
