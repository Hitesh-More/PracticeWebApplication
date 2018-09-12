using Microsoft.AspNet.Identity.EntityFramework;
using PracticeWebApplication.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace PracticeWebApplication.Models
{

    [Table("Course")]
    public class Course
    {
        public Course()
        {
            this.Subject = new HashSet<Subject>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CourseId { get; set; }
        [Required]
        [Display(Name = "Course")]
        public string CourseName { get; set; }


        public ICollection<MappingClass> MappingClasses { get; set; }
        public ICollection<StudentData> StudentData { get; set; }



        public virtual ICollection<Subject> Subject { get; set; }
    }


}
