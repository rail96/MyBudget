using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Web.Migrations.Income;
using MyBudget.Web.Models;


namespace MyBudget.Web.Controllers
{
    public class BalanceController : Controller
    {
        private readonly IncomeContext _incomeContext;
        private readonly ExpenseContext _expenseContext;
        public BalanceController(ExpenseContext expenseContext, IncomeContext incomeContext )
        {
            _incomeContext = incomeContext;
            _expenseContext = expenseContext;
        }
        
        public IActionResult Index()
        {
            var balance = new Balance();
            balance.ExpenseTotal = _expenseContext.Expense.Sum(x => x.Price);
            balance.IncomeTotal = _incomeContext.Income.Sum(x => x.Price);
            balance.CurrentBalance = balance.IncomeTotal - balance.ExpenseTotal;

           return View(balance);

            
        }

        public IActionResult TopIncomes()
        {
            var balance = new Balance();
            foreach (var inc in _incomeContext.Income.ToList())
            {
                switch (inc.Type)
                {
                    case IncomeType.Salary:
                        balance.BalanceSalary += inc.Price;
                        break;
                    case IncomeType.Scholarship:
                        balance.BalanceScholarship += inc.Price;
                        break;
                    case IncomeType.Business:
                        balance.BalanceBusiness += inc.Price;
                        break;
                    case IncomeType.Bank:
                        balance.BalanceBank += inc.Price;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                
            }
 
            return View(balance);

        }

        public IActionResult TopExpenses()
        {
            var balance = new Balance();
            foreach (var exp in _expenseContext.Expense.ToList())
            {
                switch (exp.Type)
                {
                    case ExpenseType.Transport:
                        balance.BalanceTransport += exp.Price;
                        break;
                    case ExpenseType.Food:
                        balance.BalanceFood += exp.Price;
                        break;
                    case ExpenseType.Insurance:
                        balance.BalanceInsurance += exp.Price;
                        break;
                    case ExpenseType.Clothes:
                        balance.BalanceClothes += exp.Price;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
            }

            return View(balance);

        }

    }
}