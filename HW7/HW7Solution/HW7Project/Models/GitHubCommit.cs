using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW7Project.Models
{
    public class GitHubCommit
    {
        public string SHA { get; set; }
        public Commit Commit { get; set; }
    }
}
