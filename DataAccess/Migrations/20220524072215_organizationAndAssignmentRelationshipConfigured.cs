using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class organizationAndAssignmentRelationshipConfigured : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_OrganizationId",
                table: "Assignments",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Organizations_OrganizationId",
                table: "Assignments",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Organizations_OrganizationId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_OrganizationId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Assignments");
        }
    }
}
