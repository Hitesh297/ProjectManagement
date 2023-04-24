using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class addColumnNetProfit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<decimal>(
                name: "NetProfit",
                table: "MonthData",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d2e2266-eee2-4a27-9c2d-a7e35474e29b", "f591fc3a-e7c1-442a-a61b-6933c211cfac", "Employee", "EMPLOYEE" },
                    { "c832118b-8d6b-4bbe-9717-488c2e4652a7", "8a773a3c-8f1d-45ae-ab8b-48fac87a8d9a", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "430a347a-b37d-4a65-88ff-e0876804ddb9", 0, "c65b0262-3dc8-439c-947c-62fce18ce535", "employee@gmail.com", true, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAENZE5gbQic/203V5VmUbcmZ1Q6zCNfiva8OvIqnRfDlagShtgAbOzxyWBndAooLctA==", null, false, "135ab714-59d9-4d9d-86ec-eab1335f0ee7", false, "employee@gmail.com" },
                    { "6d5fbb99-9b60-4431-b24b-019bc577b4e8", 0, "1c8e2cd3-c8d4-4249-a121-7dd7fce4f1c5", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEE4QUlTxExFOvuRgl+LL1CZrNpFEh/0oOHzNL6oRMCoes1pAUDAVphlkjEyFtdibfQ==", null, false, "68eb89ab-2e4d-40f3-84c9-db06caf63b2b", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8d2e2266-eee2-4a27-9c2d-a7e35474e29b", "430a347a-b37d-4a65-88ff-e0876804ddb9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c832118b-8d6b-4bbe-9717-488c2e4652a7", "6d5fbb99-9b60-4431-b24b-019bc577b4e8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8d2e2266-eee2-4a27-9c2d-a7e35474e29b", "430a347a-b37d-4a65-88ff-e0876804ddb9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c832118b-8d6b-4bbe-9717-488c2e4652a7", "6d5fbb99-9b60-4431-b24b-019bc577b4e8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d2e2266-eee2-4a27-9c2d-a7e35474e29b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c832118b-8d6b-4bbe-9717-488c2e4652a7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "430a347a-b37d-4a65-88ff-e0876804ddb9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5fbb99-9b60-4431-b24b-019bc577b4e8");

            migrationBuilder.DropColumn(
                name: "NetProfit",
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
        }
    }
}
