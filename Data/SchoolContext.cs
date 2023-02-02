using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetCore7.Models;

namespace AspNetCore7.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        //학생
        public DbSet<Student> Students { get; set; }        
        //교수
        public DbSet<Instructor> Instructors { get; set; }
        //교수 연구실
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        //학과
        public DbSet<Department> Departments { get; set; }
        //강좌(학과목)
        public DbSet<Course> Courses { get; set; }        
        //학생수강(학점포함)
        public DbSet<Enrollment> Enrollments { get; set; }
        
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Course>().ToTable(nameof(Course));
            //modelBuilder.Entity<Enrollment>().ToTable(nameof(Enrollment));

            // 강좌
            modelBuilder.Entity<Course>().ToTable(nameof(Course))
                .HasMany(c => c.Instructors) //다수 강사
                .WithMany(i => i.Courses); //Course 1 :

            modelBuilder.Entity<Student>().ToTable(nameof(Student));
            modelBuilder.Entity<Instructor>().ToTable(nameof(Instructor));
        }
    }
}
