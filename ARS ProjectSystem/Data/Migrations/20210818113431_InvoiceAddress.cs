namespace ARS_ProjectSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InvoiceAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerAdress",
                table: "Invoices",
                newName: "CustomerAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerAddress",
                table: "Invoices",
                newName: "CustomerAdress");
        }
    }
}
