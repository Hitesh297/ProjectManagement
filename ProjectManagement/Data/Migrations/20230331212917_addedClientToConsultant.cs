using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class addedClientToConsultant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Consultants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_ClientId",
                table: "Consultants",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_Appointments_ClientId",
                table: "Consultants",
                column: "ClientId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_Appointments_ClientId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_ClientId",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Consultants");
        }
    }
}
