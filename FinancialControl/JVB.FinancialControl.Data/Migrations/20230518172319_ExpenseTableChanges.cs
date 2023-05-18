using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JVB.FinancialControl.Data.Migrations
{
    public partial class ExpenseTableChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeginDate",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Expense");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Expense",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Expense");

            migrationBuilder.AddColumn<DateTime>(
                name: "BeginDate",
                table: "Expense",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Expense",
                type: "datetime2",
                nullable: true);
        }
    }
}
