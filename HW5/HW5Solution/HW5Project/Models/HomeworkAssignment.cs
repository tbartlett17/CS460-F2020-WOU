using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW5Project.Models
{
    public class HomeworkAssignment
    {
        public int ID { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime TimeDue { get; set; }
        public string Department { get; set; }
        public int CourseNumber { get; set; }
        public string Assignment { get; set; }
        public string Notes { get; set; }
    }
}
