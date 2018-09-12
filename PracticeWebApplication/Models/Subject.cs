using Microsoft.AspNet.Identity.EntityFramework;
using PracticeWebApplication.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace PracticeWebApplication.Models
{
    [Table("Subject")]
    public class Subject
    {
        public Subject()
        {
            this.Courses = new HashSet<Course>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SubjectId { get; set; }
        [Required]
        [Display(Name = "Course")]
        public string SubjectName { get; set; }

        public ICollection<MappingClass> MappingClasses { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
    
}
