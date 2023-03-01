using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Examination.Models;

namespace Examination.Data
{
    public class ExaminationContext : DbContext
    {
        public ExaminationContext (DbContextOptions<ExaminationContext> options)
            : base(options)
        {
        }

        public DbSet<Examination.Models.Department> Department { get; set; } = default!;

        public DbSet<Examination.Models.Employee> Employee { get; set; } = default!;
    }
}
