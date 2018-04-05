using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyBudget.Web.Migrations
{
    public partial class NewExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Expense");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfType",
                table: "Expense",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfType",
                table: "Expense");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Expense",
                nullable: true);
        }
    }
}
