using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Web.Models
{
    public class ExpensesList
    {
        public IEnumerable<Expense> Expenses { get; set; }

        public decimal TotalSum { get; set; }

        
    }
}
