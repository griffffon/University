namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subscription
    {
        public int ID { get; set; }

        public int GroupID { get; set; }

        public int SubjectID { get; set; }

        public virtual Group Group { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
