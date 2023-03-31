using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class ForeignkeyfixConsultants13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_RecruiterMemberId",
                table: "Consultants");

            migrationBuilder.RenameColumn(
                name: "RecruiterMemberId",
                table: "Consultants",
                newName: "TeamMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultants_RecruiterMemberId",
                table: "Consultants",
                newName: "IX_Consultants_TeamMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_TeamMemberId",
                table: "Consultants",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_TeamMemberId",
                table: "Consultants");

            migrationBuilder.RenameColumn(
                name: "TeamMemberId",
                table: "Consultants",
                newName: "RecruiterMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultants_TeamMemberId",
                table: "Consultants",
                newName: "IX_Consultants_RecruiterMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_RecruiterMemberId",
                table: "Consultants",
                column: "RecruiterMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
