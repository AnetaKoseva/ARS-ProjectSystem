using Microsoft.EntityFrameworkCore.Migrations;

namespace ARS_ProjectSystem.Data.Migrations
{
    public partial class UpdateInvoiceCustomerEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerOwnerName",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerOwnerName",
                table: "Invoices");
        }
    }
}
