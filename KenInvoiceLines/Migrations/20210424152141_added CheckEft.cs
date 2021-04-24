using Microsoft.EntityFrameworkCore.Migrations;

namespace KenInvoiceLines.Migrations
{
    public partial class addedCheckEft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CheckEft",
                table: "InvoicePayments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckEft",
                table: "InvoicePayments");
        }
    }
}
