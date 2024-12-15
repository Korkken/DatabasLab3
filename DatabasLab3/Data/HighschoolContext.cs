using System;
using System.Collections.Generic;
using DatabasLab3.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabasLab3.Data;

public partial class HighschoolContext : DbContext
{
    public HighschoolContext()
    {
    }

    public HighschoolContext(DbContextOptions<HighschoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = Highschool;Integrated Security = True; Encrypt = True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__CB1927C0EA4E87D9");

            entity.ToTable("Class");

            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Class__TeacherId__29572725");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71A7EB0FEE77");

            entity.ToTable("Course");

            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Grade1)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Grade");
            entity.Property(e => e.GradeId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Course).WithMany()
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Grades__CourseId__300424B4");

            entity.HasOne(d => d.Person).WithMany()
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__Grades__PersonId__2F10007B");

            entity.HasOne(d => d.Teacher).WithMany()
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__Grades__TeacherI__30F848ED");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Person__AA2FFBE53B3EC110");

            entity.ToTable("Person");

            entity.HasIndex(e => e.Ssn, "UQ__Person__CA33E0E45367D866").IsUnique();

            entity.Property(e => e.Assignment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ssn)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.HasMany(d => d.ClassesNavigation).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentClass",
                    r => r.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentCl__Class__2D27B809"),
                    l => l.HasOne<Person>().WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentCl__Stude__2C3393D0"),
                    j =>
                    {
                        j.HasKey("StudentId", "ClassId").HasName("PK__StudentC__2E74B9E5C99B3E8F");
                        j.ToTable("StudentClass");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
