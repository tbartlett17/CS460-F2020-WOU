using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HW8Project.Models
{
    public partial class Course
    {
        public Course()
        {
            Assignments = new HashSet<Assignment>();
        }

        [Key]
        [Column("course_id")]
        [StringLength(6)]
        public string CourseId { get; set; }
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }

        [InverseProperty(nameof(Assignment.Course))]
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
