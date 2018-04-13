using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Web.Models
{
    public class Balance
    {
        public int ID { get; set; }
        public decimal ExpenseTotal { get; set; }
        public decimal IncomeTotal { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal TopExpenses { get; set; }
        public decimal TopIncomes { get; set; }
        public decimal BalanceIncomeSalary { get; set; }
        public decimal BalanceIncomeScholarship{ get; set; }
        public decimal BalanceIncomeBank { get; set; }
        public decimal BalanceIncomeBusiness { get; set; }
        public decimal BalanceExpenseTransport { get; set; }
        public decimal BalanceExpenseFood { get; set; }
        public decimal BalanceExpenseInsurance{ get; set; }
        public decimal BalanceExpenseClothes { get; set; }

        public  List<decimal> BalanceExpenseMonth { get; set; }
        public List<decimal> BalanceIncomeMonth { get; set; }

    }
}
