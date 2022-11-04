using System;
using System.ComponentModel.DataAnnotations;

namespace Alcotripnics.Models
{
    public class LoginViewModel
    {
        [Required, MaxLength(20), Display(Name = "Логин")]
        public string Login { get; set; }
        
        [Required, DataType(DataType.Password), Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}

