using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyBudget.Web.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseAprSum",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "ExpenseFebSum",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "ExpenseJanSum",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "ExpenseJuneSum",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "ExpenseMarSum",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "ExpenseMaySum",
                table: "Expense");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ExpenseAprSum",
                table: "Expense",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExpenseFebSum",
                table: "Expense",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExpenseJanSum",
                table: "Expense",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExpenseJuneSum",
                table: "Expense",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExpenseMarSum",
                table: "Expense",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExpenseMaySum",
                table: "Expense",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
