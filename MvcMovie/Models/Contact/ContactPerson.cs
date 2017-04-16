using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace MvcMovie.Models
{
    public class ContactPerson
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = " required!")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = " required!")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = " required!")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter a valid Email address")]
        public string Email { get; set; }
        [DisplayName("Phone")]
        [Required(ErrorMessage = " required!")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter a valid Phone number")]
        public string Phone { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = " required!")]
        //public int State { get; set; }
        public Nullable<int> StateId { get; set; }

        public List<string> StateList { get; set; }

        int Id;

        [DisplayName("Password")]
        [Required(ErrorMessage = " required!")]
        [RegularExpression(@"^.*(?=.{8,})((?=.*\d)(?=.*[a-z])(?=.*[A-Z])|(?=.*\d)(?=.*[a-zA-Z])(?=.*[\W_])|(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])).*", ErrorMessage = "Password should be at least 8 characters and contain at least 3 of the following: upper-case, lower-case, number, and symbol")]
        //[RegularExpression(@"^.*(?=.{8})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$", ErrorMessage ="Password should be at least 8 characters long with one non-alpha numeric")]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public AgeRange? Age { get; set; }

        public enum AgeRange
        {
            Older,
            Younger
        }

        public bool AgreeToTerms { get; set; }
        public string Message { get; set; }
        public string Organization { get; set; }
    }
}