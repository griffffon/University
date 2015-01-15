namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MissingType")]
    public partial class MissingType
    {
        public MissingType()
        {
            JournalMissings = new HashSet<JournalMissing>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Abbreviation { get; set; }

        public virtual ICollection<JournalMissing> JournalMissings { get; set; }
    }
}
