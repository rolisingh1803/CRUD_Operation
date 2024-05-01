using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUDOperationInMVC.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="FirstName Is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="LastName is Requirted")]
        public string LastName { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = false)]
        //[Display(Name = "D")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage ="Email Id is Required")]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required(ErrorMessage ="Address is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Phone number is Required")]
        [MinLength(10,ErrorMessage = "Please enter valid phone number")]
        [MaxLength(10,ErrorMessage = "Please enter valid phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}