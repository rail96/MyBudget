using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyBudget.Web.Migrations
{
    public partial class ExpenseLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Expense");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Expense",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Expense");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Expense",
                nullable: false,
                defaultValue: 0);
        }
    }
}
