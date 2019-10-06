using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class CalculatorContext: DbContext
    {
        public DbSet<CalculatorResult> CalculatorResults { get; set; }
        public CalculatorContext(DbContextOptions<CalculatorContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
