using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class ForeignkeyfixConsultants134ouj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_RecruiterMemberId",
                table: "Consultants");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_TeamLeadMemberId",
                table: "Consultants");

            migrationBuilder.RenameColumn(
                name: "TeamLeadMemberId",
                table: "Consultants",
                newName: "TeamLeadId");

            migrationBuilder.RenameColumn(
                name: "RecruiterMemberId",
                table: "Consultants",
                newName: "RecruiterId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultants_TeamLeadMemberId",
                table: "Consultants",
                newName: "IX_Consultants_TeamLeadId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultants_RecruiterMemberId",
                table: "Consultants",
                newName: "IX_Consultants_RecruiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_RecruiterId",
                table: "Consultants",
                column: "RecruiterId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_TeamLeadId",
                table: "Consultants",
                column: "TeamLeadId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_RecruiterId",
                table: "Consultants");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_TeamLeadId",
                table: "Consultants");

            migrationBuilder.RenameColumn(
                name: "TeamLeadId",
                table: "Consultants",
                newName: "TeamLeadMemberId");

            migrationBuilder.RenameColumn(
                name: "RecruiterId",
                table: "Consultants",
                newName: "RecruiterMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultants_TeamLeadId",
                table: "Consultants",
                newName: "IX_Consultants_TeamLeadMemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultants_RecruiterId",
                table: "Consultants",
                newName: "IX_Consultants_RecruiterMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_RecruiterMemberId",
                table: "Consultants",
                column: "RecruiterMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_TeamLeadMemberId",
                table: "Consultants",
                column: "TeamLeadMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
