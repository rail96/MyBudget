using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyBudget.Web.Models
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext (DbContextOptions<ExpenseContext> options)
            : base(options)
        {
        }

        public DbSet<MyBudget.Web.Models.Expense> Expense { get; set; }
    }
}
