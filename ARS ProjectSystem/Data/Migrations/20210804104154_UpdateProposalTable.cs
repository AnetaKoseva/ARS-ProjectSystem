using Microsoft.EntityFrameworkCore.Migrations;

namespace ARS_ProjectSystem.Data.Migrations
{
    public partial class UpdateProposalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_Customers_CustomerId",
                table: "Proposals");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Proposals",
                newName: "CustomerRegistrationNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Proposals_CustomerId",
                table: "Proposals",
                newName: "IX_Proposals_CustomerRegistrationNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_Customers_CustomerRegistrationNumber",
                table: "Proposals",
                column: "CustomerRegistrationNumber",
                principalTable: "Customers",
                principalColumn: "RegistrationNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_Customers_CustomerRegistrationNumber",
                table: "Proposals");

            migrationBuilder.RenameColumn(
                name: "CustomerRegistrationNumber",
                table: "Proposals",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Proposals_CustomerRegistrationNumber",
                table: "Proposals",
                newName: "IX_Proposals_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_Customers_CustomerId",
                table: "Proposals",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "RegistrationNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
