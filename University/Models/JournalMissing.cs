namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JournalMissing")]
    public partial class JournalMissing
    {
        public int ID { get; set; }

        public int SubjectID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int ClassTypeID { get; set; }

        public int MissingTypeID { get; set; }

        public virtual ClassType ClassType { get; set; }

        public virtual MissingType MissingType { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
