using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Store.WebUI.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set;}

        [Required]
        public string UserPassword { get; set; }
    }
}