namespace University.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Cathedra> Cathedras { get; set; }
        public virtual DbSet<ClassType> ClassTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<JournalMark> JournalMarks { get; set; }
        public virtual DbSet<JournalMissing> JournalMissings { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MissingType> MissingTypes { get; set; }
        public virtual DbSet<QuestionType> QuestionTypes { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TestQuestion> TestQuestions { get; set; }
        public virtual DbSet<TestResult> TestResults { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cathedra>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Cathedra>()
                .Property(e => e.Abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<Cathedra>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Cathedra)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ClassType>()
                .Property(e => e.Abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<ClassType>()
                .HasMany(e => e.JournalMarks)
                .WithRequired(e => e.ClassType)
                .HasForeignKey(e => e.SubjectID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassType>()
                .HasMany(e => e.JournalMissings)
                .WithRequired(e => e.ClassType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Cathedras)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .Property(e => e.GroupName)
                .IsUnicode(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.UnivGroupID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Subscriptions)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.Material1)
                .IsUnicode(false);

            modelBuilder.Entity<MissingType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MissingType>()
                .Property(e => e.Abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<MissingType>()
                .HasMany(e => e.JournalMissings)
                .WithRequired(e => e.MissingType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionType>()
                .HasMany(e => e.TestQuestions)
                .WithRequired(e => e.QuestionType1)
                .HasForeignKey(e => e.QuestionType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.TestResults)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.JournalMarks)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.JournalMissings)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Materials)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Subscriptions)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Tests)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Subjects)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.LecturerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TestQuestion>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<TestQuestion>()
                .Property(e => e.Answer1)
                .IsUnicode(false);

            modelBuilder.Entity<TestQuestion>()
                .Property(e => e.Answer2)
                .IsUnicode(false);

            modelBuilder.Entity<TestQuestion>()
                .Property(e => e.Answer3)
                .IsUnicode(false);

            modelBuilder.Entity<TestQuestion>()
                .Property(e => e.Answer4)
                .IsUnicode(false);

            modelBuilder.Entity<TestQuestion>()
                .Property(e => e.Answer5)
                .IsUnicode(false);

            modelBuilder.Entity<Test>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.TestQuestions)
                .WithRequired(e => e.Test)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.TestResults)
                .WithRequired(e => e.Test)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<UserType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserType>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.UserType)
                .WillCascadeOnDelete(false);
        }
    }
}
