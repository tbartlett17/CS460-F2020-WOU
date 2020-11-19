using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW7Project.Models
{
    public class GitHubRepo
    {
        public string Name { get; set; }
        public string Updated_at { get; set; }
        public GitHubUser Owner { get; set; }
    }
}
