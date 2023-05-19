﻿using System.ComponentModel.DataAnnotations;

namespace JVB.FinancialControl.Common.Login
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberLogin { get; set; }
    }
}