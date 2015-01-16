using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace University.Models
{
    public class RegisterTeacherViewModel
    {
        [Required]
        [StringLength(30)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [StringLength(300)]
        public string Address { get; set; }

        public int UserTypeID { get; set; }

        public bool AdminAccount { get; set; }

        public List<SelectListItem> Departments = new List<SelectListItem>();
        public string SelectedDeptID { get; set; }

        public List<SelectListItem> Cathedras = new List<SelectListItem>();
        public string SelectedCathID { get; set; }
        //public int? CathedraID { get; set; }
    }
}