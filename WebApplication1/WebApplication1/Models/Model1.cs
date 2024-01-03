using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batch>()
                .Property(e => e.batch1)
                .IsUnicode(false);

            modelBuilder.Entity<Batch>()
                .Property(e => e.year)
                .IsUnicode(false);

            modelBuilder.Entity<Batch>()
                .HasMany(e => e.Reistrations)
                .WithOptional(e => e.Batch)
                .HasForeignKey(e => e.batch_id);

            modelBuilder.Entity<Course>()
                .Property(e => e.course1)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Reistrations)
                .WithOptional(e => e.Course)
                .HasForeignKey(e => e.course_id);

            modelBuilder.Entity<Registration>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Registration>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Registration>()
                .Property(e => e.nic)
                .IsUnicode(false);

            modelBuilder.Entity<Registration>()
                .HasOptional(e => e.Registrations)
                .WithRequired(e => e.Reistration2);

            modelBuilder.Entity<user>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
