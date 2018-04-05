using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            decimal expenseSum = _expenseContext.Expense.Sum(x => x.Price);
            decimal incomeSum = _incomeContext.Income.Sum(x => x.Price); ;

            decimal balanceSum = incomeSum - expenseSum;
            return View(balanceSum);

            
        }
                      
    }
}