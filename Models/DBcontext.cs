using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace assignmentv2.Models
{
    public partial class DBcontext : DbContext
    {
        public DBcontext()
            : base("name=DBcontext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<course> courses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<CategoryCourse> CategoryCourses { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<TrainingStaff> TrainingStaffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Trainee>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
