using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TravelPackage.Models
{
    [MetadataType(typeof(WebInquiryFormMD))]    
    public partial class WebInquiryForm
    {
        public class WebInquiryFormMD
        {

            //[Required]
            //public string LeadGuest { get; set; }

            //[Display(Name = "NoOfAdult")]
            //[Required(ErrorMessage = "Value is required")]
            [Range(1,999,ErrorMessage = "Enter valid values between 1-999")]
            public int NoOfAdult { get; set; }

            //[Display(Name = "Child")]
            //[Required(ErrorMessage = "Value is required")]
            //[Range(0, 999, ErrorMessage = "Enter valid values between 0-999")]
            //public int NoOfChild { get; set; }


            [Display(Name = "Email")]
            [Required(ErrorMessage = "The email address is required")]
            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string Email { get; set; }

            //[Display(Name = "Message")]
            //[Required(ErrorMessage = "We want to hear from you.")]
            //public string Message { get; set; }

            //[Display(Name = "Contact#")]
            //public string ContactNo { get; set; }
            //[Display(Name = "Travel Date")]
            //public DateTime JobStart { get; set; }

        }
    }


}