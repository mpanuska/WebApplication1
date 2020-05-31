using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EmailFormModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        
        [Required]
        [Display(Name = "Body")]
        public string Body { get; set; }
    }
}