using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsoleDB.Entities;
using TestConsoleDB.Data;

namespace TestConsoleDB.Data
{
    class StudentsDb : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public StudentsDb(DbContextOptions<StudentsDb> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            model.Entity<Student>()
               .Property(s => s.LastName)
               .HasMaxLength(150)
               .IsRequired();

            model.Entity<Student>()
               .Property(s => s.Name)
               .IsRequired();
         
        }

    }
}
