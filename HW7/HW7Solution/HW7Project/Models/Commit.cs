using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW7Project.Models
{
    public class Commit
    {
        public Commiter Author { get; set; }
        public string Message { get; set; }
    }
}
