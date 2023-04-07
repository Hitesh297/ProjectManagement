using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class monthdataforeignkeyfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthData_Timesheets_Timesheet",
                table: "MonthData");

            migrationBuilder.DropIndex(
                name: "IX_MonthData_Timesheet",
                table: "MonthData");

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

            migrationBuilder.DropColumn(
                name: "Timesheet",
                table: "MonthData");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b716d139-ae06-4eee-9474-71438c5e26d7", "b6a03bac-3e4d-4158-93ba-249a9210896a", "Admin", "ADMIN" },
                    { "be0d8c91-959a-4351-8678-050b24dd342d", "444e029c-b770-4db0-83be-3bf68674ab5c", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "02da125c-989c-4d91-9e37-c2618f95d204", 0, "b9a327e3-7e9a-442f-bc40-72e6c7a2d07c", "employee@gmail.com", true, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEGk5ra80PdUAluwp2PpD/eG7Z+qmtxG0S5R8dpxXh+/vZsT5+hFFImuq1iKwkt5twg==", null, false, "ee27bd49-c384-4fcb-817f-d86a83261e27", false, "employee@gmail.com" },
                    { "3ad9b083-879c-4ade-a3dc-b6dc4c6e0d43", 0, "75742462-d35d-43c0-8d40-753e7f1f98f7", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEFTJAMwRDcPpX5MHXUIwxCEdfJAO6NOjdV0EY4R9QpVaeUAR/98p+G/3AGxDlIuGyg==", null, false, "a575b5cf-29a5-48f0-8589-e507820d3db1", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "be0d8c91-959a-4351-8678-050b24dd342d", "02da125c-989c-4d91-9e37-c2618f95d204" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b716d139-ae06-4eee-9474-71438c5e26d7", "3ad9b083-879c-4ade-a3dc-b6dc4c6e0d43" });

            migrationBuilder.CreateIndex(
                name: "IX_MonthData_TimesheetId",
                table: "MonthData",
                column: "TimesheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthData_Timesheets_TimesheetId",
                table: "MonthData",
                column: "TimesheetId",
                principalTable: "Timesheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthData_Timesheets_TimesheetId",
                table: "MonthData");

            migrationBuilder.DropIndex(
                name: "IX_MonthData_TimesheetId",
                table: "MonthData");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "be0d8c91-959a-4351-8678-050b24dd342d", "02da125c-989c-4d91-9e37-c2618f95d204" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b716d139-ae06-4eee-9474-71438c5e26d7", "3ad9b083-879c-4ade-a3dc-b6dc4c6e0d43" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b716d139-ae06-4eee-9474-71438c5e26d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be0d8c91-959a-4351-8678-050b24dd342d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02da125c-989c-4d91-9e37-c2618f95d204");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ad9b083-879c-4ade-a3dc-b6dc4c6e0d43");

            migrationBuilder.AddColumn<int>(
                name: "Timesheet",
                table: "MonthData",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_MonthData_Timesheets_Timesheet",
                table: "MonthData",
                column: "Timesheet",
                principalTable: "Timesheets",
                principalColumn: "Id");
        }
    }
}
