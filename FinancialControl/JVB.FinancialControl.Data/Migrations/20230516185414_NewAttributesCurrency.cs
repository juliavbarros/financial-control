using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JVB.FinancialControl.Data.Migrations
{
    public partial class NewAttributesCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Currency",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Currency",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Currency");
        }
    }
}