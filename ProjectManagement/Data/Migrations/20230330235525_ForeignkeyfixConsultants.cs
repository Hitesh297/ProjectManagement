using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class ForeignkeyfixConsultants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_TeamMemberId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_TeamMemberId",
                table: "Consultants");

            migrationBuilder.RenameColumn(
                name: "TeamMemberId",
                table: "Consultants",
                newName: "RecruiterMemberId");

            migrationBuilder.AddColumn<int>(
                name: "RecruiterId",
                table: "Consultants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_RecruiterId",
                table: "Consultants",
                column: "RecruiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_RecruiterId",
                table: "Consultants",
                column: "RecruiterId",
                principalTable: "TeamMembers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_RecruiterId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_RecruiterId",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "RecruiterId",
                table: "Consultants");

            migrationBuilder.RenameColumn(
                name: "RecruiterMemberId",
                table: "Consultants",
                newName: "TeamMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_TeamMemberId",
                table: "Consultants",
                column: "TeamMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_TeamMemberId",
                table: "Consultants",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
