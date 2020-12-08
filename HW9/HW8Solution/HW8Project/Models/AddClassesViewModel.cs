using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HW8Project.Models
{
    public class AddClassesViewModel
    {
        [Required]
        public string Input { get; set; }
    }
}
