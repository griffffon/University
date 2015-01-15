namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        public Student()
        {
            TestResults = new HashSet<TestResult>();
        }

        public int ID { get; set; }

        public int UserID { get; set; }

        public int UnivGroupID { get; set; }

        public virtual Group Group { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
