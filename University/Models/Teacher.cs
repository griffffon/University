namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Teacher
    {
        public Teacher()
        {
            Subjects = new HashSet<Subject>();
        }

        public int ID { get; set; }

        public int UserID { get; set; }

        public int? CathedraID { get; set; }

        public virtual Cathedra Cathedra { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

        public virtual User User { get; set; }
    }
}
