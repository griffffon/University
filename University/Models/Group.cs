namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
            Subscriptions = new HashSet<Subscription>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupName { get; set; }

        public int CathedraID { get; set; }

        public virtual Cathedra Cathedra { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
