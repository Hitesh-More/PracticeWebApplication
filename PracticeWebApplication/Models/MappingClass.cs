using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeWebApplication.Models
{
    [Table("MappingClass")]
    public class MappingClass
    {
        

        [Key]
        public long MappingId { get; set; }

        public long CourseId { get; set; }
        public Course Course { get; set; }                  //for foreign key

        public long SubjectId { get; set; }
        public Subject Subject { get; set; }

        public List<String> LstStringForMapping { get; set; }

        public List<StudentData> StudentData { get; set; }

   
    }
}