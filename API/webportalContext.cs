using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API
{
    public partial class webportalContext : DbContext
    {
        public webportalContext()
        {
        }

        public webportalContext(DbContextOptions<webportalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<PersonCourse> PersonCourses { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=webportal;Username=postgres;Password=axmed2002");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Infcourse)
                    .HasMaxLength(500)
                    .HasColumnName("infcourse");

                entity.Property(e => e.Namecourse)
                    .HasMaxLength(50)
                    .HasColumnName("namecourse");

                entity.Property(e => e.Nomercourse).HasColumnName("nomercourse");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Event1)
                    .HasMaxLength(500)
                    .HasColumnName("event");

                entity.Property(e => e.Personid).HasColumnName("personid");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.Personid)
                    .HasConstraintName("event_personid_fkey");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.HasIndex(e => e.Email, "person_email_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(100)
                    .HasColumnName("lastname");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .HasColumnName("password");

                entity.Property(e => e.Surname)
                    .HasMaxLength(100)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<PersonCourse>(entity =>
            {
                entity.ToTable("person_course");

                entity.HasIndex(e => new { e.Personid, e.Courseid }, "person_course_personid_courseid_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Courseid).HasColumnName("courseid");

                entity.Property(e => e.Personid).HasColumnName("personid");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.PersonCourses)
                    .HasForeignKey(d => d.Courseid)
                    .HasConstraintName("person_course_courseid_fkey");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonCourses)
                    .HasForeignKey(d => d.Personid)
                    .HasConstraintName("person_course_personid_fkey");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("teacher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dopinf)
                    .HasMaxLength(50)
                    .HasColumnName("dopinf");

                entity.Property(e => e.Inftext)
                    .HasMaxLength(50)
                    .HasColumnName("inftext");

                entity.Property(e => e.Personid).HasColumnName("personid");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.Personid)
                    .HasConstraintName("teacher_personid_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
