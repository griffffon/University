namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Department
    {
        public Department()
        {
            Cathedras = new HashSet<Cathedra>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Abbreviation { get; set; }

        public virtual ICollection<Cathedra> Cathedras { get; set; }
    }
}
