using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyBudget.Web.Models
{
    public class IncomeContext : DbContext
    {
        public IncomeContext (DbContextOptions<IncomeContext> options)
            : base(options)
        {
        }

        public DbSet<MyBudget.Web.Models.Income> Income { get; set; }
    }
}
