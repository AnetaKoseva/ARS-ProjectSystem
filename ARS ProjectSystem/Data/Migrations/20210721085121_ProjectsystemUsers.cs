using Microsoft.EntityFrameworkCore.Migrations;

namespace ARS_ProjectSystem.Data.Migrations
{
    public partial class ProjectsystemUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "ProjectSystemUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "ProjectSystemUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ProjectSystemUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ProjectSystemUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ProjectSystemUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IBAN",
                table: "Invoices",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Invoices",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectSystemCustomerId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSystemUsers_UserId",
                table: "ProjectSystemUsers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSystemUsers_UserId1",
                table: "ProjectSystemUsers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ProjectId",
                table: "Customers",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Projects_ProjectId",
                table: "Customers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSystemUsers_AspNetUsers_UserId",
                table: "ProjectSystemUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSystemUsers_AspNetUsers_UserId1",
                table: "ProjectSystemUsers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Projects_ProjectId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSystemUsers_AspNetUsers_UserId",
                table: "ProjectSystemUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSystemUsers_AspNetUsers_UserId1",
                table: "ProjectSystemUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectSystemUsers_UserId",
                table: "ProjectSystemUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectSystemUsers_UserId1",
                table: "ProjectSystemUsers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ProjectId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ProjectSystemUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProjectSystemUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ProjectSystemUsers");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ProjectSystemCustomerId",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "ProjectSystemUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "ProjectSystemUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "IBAN",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
