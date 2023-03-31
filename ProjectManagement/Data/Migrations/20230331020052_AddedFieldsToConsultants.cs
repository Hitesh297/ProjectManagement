using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class AddedFieldsToConsultants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BillingRate",
                table: "Consultants",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CreditCardCost",
                table: "Consultants",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Consultants",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MarketingFee",
                table: "Consultants",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MarketingManagerMemberId",
                table: "Consultants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NetMargin",
                table: "Consultants",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PayRate",
                table: "Consultants",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PlacedByMemberId",
                table: "Consultants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PlacementFee",
                table: "Consultants",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ReferralFees",
                table: "Consultants",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ReferredByMemberId",
                table: "Consultants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Consultants",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TeamLeadFee",
                table: "Consultants",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TeamMemberId",
                table: "Consultants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_MarketingManagerMemberId",
                table: "Consultants",
                column: "MarketingManagerMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_PlacedByMemberId",
                table: "Consultants",
                column: "PlacedByMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_ReferredByMemberId",
                table: "Consultants",
                column: "ReferredByMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_TeamMemberId",
                table: "Consultants",
                column: "TeamMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_MarketingManagerMemberId",
                table: "Consultants",
                column: "MarketingManagerMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_PlacedByMemberId",
                table: "Consultants",
                column: "PlacedByMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_ReferredByMemberId",
                table: "Consultants",
                column: "ReferredByMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_TeamMembers_TeamMemberId",
                table: "Consultants",
                column: "TeamMemberId",
                principalTable: "TeamMembers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_MarketingManagerMemberId",
                table: "Consultants");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_PlacedByMemberId",
                table: "Consultants");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_ReferredByMemberId",
                table: "Consultants");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_TeamMembers_TeamMemberId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_MarketingManagerMemberId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_PlacedByMemberId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_ReferredByMemberId",
                table: "Consultants");

            migrationBuilder.DropIndex(
                name: "IX_Consultants_TeamMemberId",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "BillingRate",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "CreditCardCost",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "MarketingFee",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "MarketingManagerMemberId",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "NetMargin",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "PayRate",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "PlacedByMemberId",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "PlacementFee",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "ReferralFees",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "ReferredByMemberId",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "TeamLeadFee",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "TeamMemberId",
                table: "Consultants");
        }
    }
}
