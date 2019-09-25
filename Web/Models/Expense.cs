using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyBudget.Web.Models
{
 /*
  * Class for expenses
  * Contains all Expense Properties
 */ 

    public class Expense
    {
        //Primary key
        public int ID { get; set; }  
        //Expense Title
        public string Title { get; set; }
        //Expense Date
        public DateTime Date { get; set; } 
        //Expense Type
        /// <example>
        /// Food
        /// Car
        /// Insurance
        /// </example>
        public ExpenseType Type { get; set; }
        //Expense Price
        public decimal Price { get; set; } 
    }
    public enum ExpenseType
    {
        Transport = 1,
        Food = 2,
        Insurance = 3,
        Clothes = 4
    }
}
