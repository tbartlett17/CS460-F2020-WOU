using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HW8Project.Models
{
    public partial class Assignment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("priority")]
        [StringLength(10)]
        public string Priority { get; set; }
        [Column("due_date", TypeName = "date")]
        public DateTime DueDate { get; set; }
        [Required]
        [Column("course_id")]
        [StringLength(6)]
        public string CourseId { get; set; }
        [Required]
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("keywords")]
        public string Keywords { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [Column("completed")]
        public byte? Completed { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty(nameof(Models.Course.Assignments))]
        public virtual Course Course { get; set; }
    }
}
