using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW7Project.Models
{
    public class GitHubUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }

        public string Avatar_url { get; set; }
        public IEnumerable<GitHubRepo> Repos { get; set; }

    }
}
