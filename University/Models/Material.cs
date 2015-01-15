namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Material
    {
        public int ID { get; set; }

        public int SubjectID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("Material")]
        public string Material1 { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
