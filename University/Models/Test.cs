namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Test
    {
        public Test()
        {
            TestQuestions = new HashSet<TestQuestion>();
            TestResults = new HashSet<TestResult>();
        }

        public int ID { get; set; }

        public int SubjectID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int QuestionsCount { get; set; }

        public TimeSpan TimeCount { get; set; }

        public int Efforts { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual ICollection<TestQuestion> TestQuestions { get; set; }

        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
