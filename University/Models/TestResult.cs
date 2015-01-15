namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TestResult
    {
        public int ID { get; set; }

        public int TestID { get; set; }

        public int StudentID { get; set; }

        public int CorrectPoints { get; set; }

        public int TotalPoints { get; set; }

        public virtual Student Student { get; set; }

        public virtual Test Test { get; set; }
    }
}
