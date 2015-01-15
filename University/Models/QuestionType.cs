namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuestionType")]
    public partial class QuestionType
    {
        public QuestionType()
        {
            TestQuestions = new HashSet<TestQuestion>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public virtual ICollection<TestQuestion> TestQuestions { get; set; }
    }
}
