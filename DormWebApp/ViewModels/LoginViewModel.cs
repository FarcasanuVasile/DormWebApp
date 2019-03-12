﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DormWebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember me?")]
        public bool RememberMe { get; set; }
        public LoginViewModel()
        {

        }
    }
}