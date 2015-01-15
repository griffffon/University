namespace University.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TestQuestion
    {
        public int ID { get; set; }

        public int TestID { get; set; }

        [Required]
        [StringLength(200)]
        public string Question { get; set; }

        public int QuestionType { get; set; }

        [Required]
        [StringLength(200)]
        public string Answer1 { get; set; }

        public byte Correct1 { get; set; }

        [Required]
        [StringLength(200)]
        public string Answer2 { get; set; }

        public byte Correct2 { get; set; }

        [Required]
        [StringLength(200)]
        public string Answer3 { get; set; }

        public byte Correct3 { get; set; }

        [Required]
        [StringLength(200)]
        public string Answer4 { get; set; }

        public byte Correct4 { get; set; }

        [Required]
        [StringLength(200)]
        public string Answer5 { get; set; }

        public byte Correct5 { get; set; }

        public virtual QuestionType QuestionType1 { get; set; }

        public virtual Test Test { get; set; }
    }
}
