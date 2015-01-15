using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University.Models
{
    public class UserAuthViewModel
    {
        [Required(ErrorMessage = "Введите логин", AllowEmptyStrings = false)]
        [StringLength(30)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Password { get; set; }
    }
}