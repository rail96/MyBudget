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
        public decimal BalanceSalary { get; set; }
        public decimal BalanceScholarship{ get; set; }
        public decimal BalanceBank { get; set; }
        public decimal BalanceBusiness { get; set; }
        public decimal BalanceTransport { get; set; }
        public decimal BalanceFood { get; set; }
        public decimal BalanceInsurance{ get; set; }
        public decimal BalanceClothes { get; set; }

    }
}
