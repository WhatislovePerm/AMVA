using System;
using System.ComponentModel.DataAnnotations;

namespace Alcotripnics.Models
{
    public class RegistrationViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Пароль"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Подтвердите пароль"), DataType(DataType.Password), Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

    }
}

