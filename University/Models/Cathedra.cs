namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cathedra
    {
        public Cathedra()
        {
            Groups = new HashSet<Group>();
            Teachers = new HashSet<Teacher>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Abbreviation { get; set; }

        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
