using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University.Models
{
    public class PasswordRecoveryViewModel
    {
        [StringLength(40)]
        [Required(ErrorMessage="Введите Ваш e-mail")]
        public string Email { get; set; }
    }
}