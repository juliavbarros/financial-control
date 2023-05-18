using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JVB.FinancialControl.Data.Migrations
{
    public partial class PropertyChangedQuotationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Quotation");

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Quotation",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Quotation");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Quotation",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
