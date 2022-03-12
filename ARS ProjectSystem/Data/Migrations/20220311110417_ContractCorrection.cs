using Microsoft.EntityFrameworkCore.Migrations;

namespace ARS_ProjectSystem.Data.Migrations
{
    public partial class ContractCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "CustomerAddress",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerCountry",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerOwnerName",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhoneNumber",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerTown",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerUrl",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerVAT",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Customers_CustomerRegistrationNumber",
                table: "Contracts",
                column: "CustomerRegistrationNumber",
                principalTable: "Customers",
                principalColumn: "RegistrationNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Customers_CustomerRegistrationNumber",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CustomerAddress",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CustomerCountry",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CustomerOwnerName",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CustomerPhoneNumber",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CustomerTown",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CustomerUrl",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CustomerVAT",
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
    }
}
