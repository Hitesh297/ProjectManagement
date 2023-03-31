using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class ForeignkeyfixConsultants1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_RecruiterMemberId",
                table: "Consultants",
                column: "RecruiterMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_RecruiterMemberId",
                table: "Consultants",
                column: "RecruiterMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_RecruiterMemberId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_RecruiterMemberId",
                table: "Consultants");

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
    }
}
