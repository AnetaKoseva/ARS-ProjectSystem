namespace ARS_ProjectSystem.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    public partial class AddproposalLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abstract",
                table: "Proposals",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureKnowledge1",
                table: "Proposals",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureKnowledge2",
                table: "Proposals",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureName1",
                table: "Proposals",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureName2",
                table: "Proposals",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureTechnology1",
                table: "Proposals",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeatureTechnology2",
                table: "Proposals",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreeKeyword",
                table: "Proposals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullProposalTitle",
                table: "Proposals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HowProblemIsSolved",
                table: "Proposals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Keyword1Child",
                table: "Proposals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Keyword1Parent",
                table: "Proposals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Keyword2Child",
                table: "Proposals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Keyword2Parent",
                table: "Proposals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Keyword3Child",
                table: "Proposals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Keyword3Parent",
                table: "Proposals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProblemSolve",
                table: "Proposals",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectAcronym",
                table: "Proposals",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectPurpose",
                table: "Proposals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Solution",
                table: "Proposals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SolutionDescribtion",
                table: "Proposals",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SolutionType",
                table: "Proposals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abstract",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "FeatureKnowledge1",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "FeatureKnowledge2",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "FeatureName1",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "FeatureName2",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "FeatureTechnology1",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "FeatureTechnology2",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "FreeKeyword",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "FullProposalTitle",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "HowProblemIsSolved",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "Keyword1Child",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "Keyword1Parent",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "Keyword2Child",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "Keyword2Parent",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "Keyword3Child",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "Keyword3Parent",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "ProblemSolve",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "ProjectAcronym",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "ProjectPurpose",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "Solution",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "SolutionDescribtion",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "SolutionType",
                table: "Proposals");
        }
    }
}
