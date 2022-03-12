using Microsoft.EntityFrameworkCore.Migrations;

namespace ARS_ProjectSystem.Data.Migrations
{
    public partial class AddContarctsCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Customers_CustomerRegistrationNumber",
                table: "Contracts");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerRegistrationNumber",
                table: "Contracts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Customers_CustomerRegistrationNumber",
                table: "Contracts",
                column: "CustomerRegistrationNumber",
                principalTable: "Customers",
                principalColumn: "RegistrationNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Customers_CustomerRegistrationNumber",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Contracts");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerRegistrationNumber",
                table: "Contracts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Customers_CustomerRegistrationNumber",
                table: "Contracts",
                column: "CustomerRegistrationNumber",
                principalTable: "Customers",
                principalColumn: "RegistrationNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
