using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerAgi.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? LogoUrl { get; set; }
        public string? Website { get; set; }
        public string? Industry { get; set; }
        public string? Description { get; set; }

    }
}
