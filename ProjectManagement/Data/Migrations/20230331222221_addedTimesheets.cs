using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class addedTimesheets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultantId = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    JanBilling = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FebBilling = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MarBilling = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AprBilling = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MayBilling = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JunBilling = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JulBilling = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AugBilling = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SepBilling = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OctBilling = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NovBilling = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DecBilling = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timesheets_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_ConsultantId",
                table: "Timesheets",
                column: "ConsultantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timesheets");
        }
    }
}
