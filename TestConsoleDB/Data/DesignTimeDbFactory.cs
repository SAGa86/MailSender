using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleDB.Data
{
    class DesignTimeDbFactory
    {
        public StudentsDb CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<StudentsDb>()
               .UseLazyLoadingProxies()
               .UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog=Students.DB")
               .Options;

            return new StudentsDb(options);
        }
    }
}
