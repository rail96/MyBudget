﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Web.Models
{
    /*
      * Class for incomes
      * Contains all Income's Properties
     */
    public class Income
    {
        //Primary key
        public int ID { get; set; }
        //Income's Title
        public string Title { get; set; }
        //Income's Date
        public DateTime Date { get; set; }
        //Income's Type
        /// <example>
        /// Calary
        /// Scholarship
        /// Business
        /// </summary>
        public string Type { get; set; }
        //Income's price 
        public decimal Price { get; set; } 
    }
}