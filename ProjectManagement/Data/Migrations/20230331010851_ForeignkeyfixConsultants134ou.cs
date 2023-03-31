using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class ForeignkeyfixConsultants134ou : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamLeadMemberId",
                table: "Consultants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_TeamLeadMemberId",
                table: "Consultants",
                column: "TeamLeadMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_TeamLeadMemberId",
                table: "Consultants",
                column: "TeamLeadMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_TeamLeadMemberId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_TeamLeadMemberId",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "TeamLeadMemberId",
                table: "Consultants");
        }
    }
}
