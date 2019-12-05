using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PublishingHouse.BLL.DTOs
{
    public class RegisterDto
    {
        [Required]
        [Display(Name = "Ім'я користувача")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

       // [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Підтвердіть пароль")]
        [Compare("Password",
            ErrorMessage = "Пароль та його підтвердження не співпадають")]
        public string ConfirmPassword { get; set; }
    }
}
