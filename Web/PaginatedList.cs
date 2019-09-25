using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyBudget.Web
{
    public class PaginatedList<T> 
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public List<T> Items { get; private set; }
        public decimal TotalIncomePrice { get; set; }
        public decimal TotalExpensePrice { get; set; }

        public PaginatedList(List<T> items, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            int count = items.Count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.Items = items.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
        }



        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        
    }
}
