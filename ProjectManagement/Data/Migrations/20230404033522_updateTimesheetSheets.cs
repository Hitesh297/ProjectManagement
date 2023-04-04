using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class updateTimesheetSheets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bc48db58-ee6a-42d0-9cec-a4106da8821f", "bcd4cd30-dd84-4826-b87f-cb1f18324602" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f2c24e2b-5a8a-4134-9a0d-3f5a70a6c014", "bffc0bb2-f9cd-4858-8908-7a783ef9f46b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc48db58-ee6a-42d0-9cec-a4106da8821f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2c24e2b-5a8a-4134-9a0d-3f5a70a6c014");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcd4cd30-dd84-4826-b87f-cb1f18324602");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bffc0bb2-f9cd-4858-8908-7a783ef9f46b");

            migrationBuilder.DropColumn(
                name: "ConsultantPay",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "InvoiceAmount",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "MonthInt",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "Variation",
                table: "Timesheets");

            migrationBuilder.CreateTable(
                name: "MonthData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthInt = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConsultantPay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Variation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TimesheetId = table.Column<int>(type: "int", nullable: false),
                    Timesheet = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthData_Timesheets_Timesheet",
                        column: x => x.Timesheet,
                        principalTable: "Timesheets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54e4ef70-060b-40cd-bc02-d9c685e42435", "0ae7a4d8-048b-4865-89c7-67d386e017dc", "Employee", "EMPLOYEE" },
                    { "7e2653aa-3d44-4b32-8cc4-cfe9e03f906e", "43d96624-4dcb-4b09-abc2-816fc5656cbf", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3ee41e96-7f02-42fe-8cea-1c76ca2f9a05", 0, "290a886e-ca91-4efb-9fca-80a0c71d611a", "employee@gmail.com", true, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEA+K+Xkwpfu3pEg76FXvFOw6WnCtLxXPUbQVSkEdxTM1G2rtvYkmLJCS0aw9q58XRw==", null, false, "d8890b3b-8570-407d-9b30-478191137c1b", false, "employee@gmail.com" },
                    { "c377a0ba-bc20-40a0-ad8c-7de4c0fd7719", 0, "6601d30d-444c-4fd7-a505-b2f9bf3a60f9", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEOS3FZxtH85mOmALSL4j5O1xnbHSTEce0QULqCDnAWeaSfaCq7fUKcVvPD3n7upHAQ==", null, false, "07637477-5211-400a-96d2-3a1a91c46efb", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "54e4ef70-060b-40cd-bc02-d9c685e42435", "3ee41e96-7f02-42fe-8cea-1c76ca2f9a05" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7e2653aa-3d44-4b32-8cc4-cfe9e03f906e", "c377a0ba-bc20-40a0-ad8c-7de4c0fd7719" });

            migrationBuilder.CreateIndex(
                name: "IX_MonthData_Timesheet",
                table: "MonthData",
                column: "Timesheet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthData");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "54e4ef70-060b-40cd-bc02-d9c685e42435", "3ee41e96-7f02-42fe-8cea-1c76ca2f9a05" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7e2653aa-3d44-4b32-8cc4-cfe9e03f906e", "c377a0ba-bc20-40a0-ad8c-7de4c0fd7719" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54e4ef70-060b-40cd-bc02-d9c685e42435");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e2653aa-3d44-4b32-8cc4-cfe9e03f906e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ee41e96-7f02-42fe-8cea-1c76ca2f9a05");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c377a0ba-bc20-40a0-ad8c-7de4c0fd7719");

            migrationBuilder.AddColumn<decimal>(
                name: "ConsultantPay",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Hours",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InvoiceAmount",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "Timesheets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MonthInt",
                table: "Timesheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PaidAmount",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Variation",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bc48db58-ee6a-42d0-9cec-a4106da8821f", "50d26496-1df3-4e97-9c20-9700d591f509", "Employee", "EMPLOYEE" },
                    { "f2c24e2b-5a8a-4134-9a0d-3f5a70a6c014", "acf999f4-bfa1-43d3-b1a1-101288845b24", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bcd4cd30-dd84-4826-b87f-cb1f18324602", 0, "5f3048e1-655f-4d75-9527-45843052a3b2", "employee@gmail.com", true, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEDFJtuzT46yKFe/szYImXEOKfpUyibeiF4BdHCnkLsvdxmF4Z1RSDOzfeLvAH9Kx4Q==", null, false, "3c3ade55-0dc8-4937-9744-a11e3bf9e3c4", false, "employee@gmail.com" },
                    { "bffc0bb2-f9cd-4858-8908-7a783ef9f46b", 0, "a6c4a4ea-b24f-4b99-9c88-50371d920946", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAECgfh3Qy5j3+6/izQnFbbZGcLP0MWfJP26bmkzoEOabLW9gEBsAERDloYvbEsaIRPw==", null, false, "74933742-2398-4907-adee-fcee312d72f2", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bc48db58-ee6a-42d0-9cec-a4106da8821f", "bcd4cd30-dd84-4826-b87f-cb1f18324602" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f2c24e2b-5a8a-4134-9a0d-3f5a70a6c014", "bffc0bb2-f9cd-4858-8908-7a783ef9f46b" });
        }
    }
}
