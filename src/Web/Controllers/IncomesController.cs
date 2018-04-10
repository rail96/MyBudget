using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBudget.Web.Models;

namespace MyBudget.Web.Controllers
{
    public class IncomesController : Controller
    {
        private readonly IncomeContext _context;

        public IncomesController(IncomeContext context)
        {
            _context = context;
        }

        // GET: Incomes
        public IActionResult Index(string sortOrder,
            string currentFilter,
            string searchString,
            int? page)
        {
            List<Income> incomesList = _context.Income.ToList();

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

            // var incomes = incomesList.Incomes.ToList();
            if (searchString != null)
            {
                incomesList = incomesList.Where(x => x.Title != null && x.Title.Contains(searchString)).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    incomesList = incomesList.OrderByDescending(s => s.Title).ToList();
                    break;
                case "Date":
                    incomesList = incomesList.OrderBy(s => s.Date).ToList();
                    break;
                case "date_desc":
                    incomesList = incomesList.OrderByDescending(s => s.Date).ToList();
                    break;
                case "type_desc":
                    incomesList = incomesList.OrderByDescending(s => s.Type).ToList();
                    break;
                case "price_desc":
                    incomesList = incomesList.OrderBy(s => s.Price).ToList();
                    break;

                default:
                    incomesList = incomesList.OrderBy(s => s.Title).ToList();
                    break;
            }

            var paginatedList = new PaginatedList<Income>(incomesList, page ?? 1, 3);

            return View(paginatedList);


        }


        // GET: Incomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var income = await _context.Income
                .SingleOrDefaultAsync(m => m.ID == id);
            if (income == null)
            {
                return NotFound();
            }

            return View(income);
        }

        // GET: Incomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Incomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Date,Type,Price")] Income income)
        {
            if (ModelState.IsValid)
            {
                _context.Add(income);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(income);
        }

        // GET: Incomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var income = await _context.Income.SingleOrDefaultAsync(m => m.ID == id);
            if (income == null)
            {
                return NotFound();
            }
            return View(income);
        }

        // POST: Incomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Date,Type,Price")] Income income)
        {
            if (id != income.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(income);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeExists(income.ID))
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
            return View(income);
        }

        // GET: Incomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var income = await _context.Income
                .SingleOrDefaultAsync(m => m.ID == id);
            if (income == null)
            {
                return NotFound();
            }

            return View(income);
        }

        // POST: Incomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var income = await _context.Income.SingleOrDefaultAsync(m => m.ID == id);
            _context.Income.Remove(income);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeExists(int id)
        {
            return _context.Income.Any(e => e.ID == id);
        }
    }
}
