namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subject
    {
        public Subject()
        {
            JournalMarks = new HashSet<JournalMark>();
            JournalMissings = new HashSet<JournalMissing>();
            Materials = new HashSet<Material>();
            Subscriptions = new HashSet<Subscription>();
            Tests = new HashSet<Test>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int LecturerID { get; set; }

        public virtual ICollection<JournalMark> JournalMarks { get; set; }

        public virtual ICollection<JournalMissing> JournalMissings { get; set; }

        public virtual ICollection<Material> Materials { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
