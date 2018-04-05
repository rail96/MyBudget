using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Web.Models
{
    public class IncomesList
    {
        public IEnumerable<Income> Incomes { get; set; }

        public decimal Total { get; set; }
    }
}
