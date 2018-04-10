using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.Web.Models;

namespace MyBudget.Web.Controllers
{
    public static class MyExtensions
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e, Name = e.ToString(CultureInfo.InvariantCulture) };
            return new SelectList(values, "Id", "Name", enumObj);
        }
    }
    public class ExpensesController : Controller
    {
        private readonly ExpenseContext _context;

        public ExpensesController(ExpenseContext context)
        {
            _context = context;
        }


        // GET: Expenses
        public IActionResult Index(string sortOrder,
            string currentFilter,
            string searchString,
            int? page)
        {
            List<Expense> expenseslist = _context.Expense.ToList();
            //  var expensesList = new ExpensesList();
            //  expensesList.TotalSum = _context.Expense.Sum(x => x.Price);
            // expensesList.Expenses = _context.Expense;

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["TypeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewData["PriceSortParm"] = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (searchString != null)
            {

                expenseslist = _context.Expense.Where(s => s.Title != null && s.Title.Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    expenseslist = expenseslist.OrderByDescending(s => s.Title).ToList();
                    break;
                case "Date":
                    expenseslist = expenseslist.OrderBy(s => s.Date).ToList();
                    break;
                case "date_desc":
                    expenseslist = expenseslist.OrderByDescending(s => s.Date).ToList();
                    break;
                case "type_desc":
                    expenseslist = expenseslist.OrderByDescending(s => s.Type).ToList();
                    break;
                case "price_desc":
                    expenseslist = expenseslist.OrderBy(s => s.Price).ToList();
                    break;

                default:
                    expenseslist = expenseslist.OrderBy(s => s.Title).ToList();
                    break;
            }

            var paginatedList = new PaginatedList<Expense>(expenseslist, page ?? 1, 3);

            return View(paginatedList);


        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var expense = await _context.Expense
                .SingleOrDefaultAsync(m => m.ID == id);
            if (expense == null)
            {
                return NotFound();
            }
            
            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Date,Type,Price")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var expense = await _context.Expense.SingleOrDefaultAsync(m => m.ID == id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Date,Type,Price")] Expense expense)
        {
            if (id != expense.ID)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expense
                .SingleOrDefaultAsync(m => m.ID == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.Expense.SingleOrDefaultAsync(m => m.ID == id);
            _context.Expense.Remove(expense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expense.Any(e => e.ID == id);
        }
    }
}
