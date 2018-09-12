using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PracticeWebApplication.Models
{
    [Table("StudentData")]
    public class StudentData
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "The First Name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "The Last Name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "The Gender is required")]
        public string Gender { get; set; }


        [Required]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "The Mobile number is required")]
        [MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Mobile number")]
        public string MobileNumber { get; set; }


        [Required(ErrorMessage = "The Address is required")]
        [MaxLength(50)]
        public string Address1 { get; set; }


        [Display(Name = "City")]
        [Required(ErrorMessage = "The City Name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string City { get; set; }


        [Display(Name = "State")]
        [Required(ErrorMessage = "The State Name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string State { get; set; }


        [Display(Name = "Country")]
        [Required(ErrorMessage = "The Country name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Country { get; set; }



        [Display(Name = "Zip")]
        [Required(ErrorMessage = "The Zip is required")]
        [Range(0, Int64.MaxValue, ErrorMessage = "Zip should not contain characters")]
        [MaxLength(6)]
        public string Zip { get; set; }

        public long CourseId { get; set; }
        public Course Course { get; set; }
    }

}


