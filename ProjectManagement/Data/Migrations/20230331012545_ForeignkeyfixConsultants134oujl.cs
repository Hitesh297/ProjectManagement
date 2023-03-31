using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class ForeignkeyfixConsultants134oujl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_RecruiterId",
                table: "Consultants");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_TeamLeadId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_RecruiterId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_TeamLeadId",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "RecruiterId",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "TeamLeadId",
                table: "Consultants");

            migrationBuilder.AddColumn<int>(
                name: "RecruiterMemberId",
                table: "Consultants",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamLeadMemberId",
                table: "Consultants",
                type: "int",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_RecruiterMemberId",
                table: "Consultants",
                column: "RecruiterMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_TeamLeadMemberId",
                table: "Consultants",
                column: "TeamLeadMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_RecruiterMemberId",
                table: "Consultants",
                column: "RecruiterMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_TeamLeadMemberId",
                table: "Consultants",
                column: "TeamLeadMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_RecruiterMemberId",
                table: "Consultants");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_TeamLeadMemberId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_RecruiterMemberId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_TeamLeadMemberId",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "RecruiterMemberId",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "TeamLeadMemberId",
                table: "Consultants");

            migrationBuilder.AddColumn<int>(
                name: "RecruiterId",
                table: "Consultants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamLeadId",
                table: "Consultants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_RecruiterId",
                table: "Consultants",
                column: "RecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_TeamLeadId",
                table: "Consultants",
                column: "TeamLeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_RecruiterId",
                table: "Consultants",
                column: "RecruiterId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_TeamLeadId",
                table: "Consultants",
                column: "TeamLeadId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
