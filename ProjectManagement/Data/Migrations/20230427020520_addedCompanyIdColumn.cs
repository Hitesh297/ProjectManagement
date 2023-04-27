using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class addedCompanyIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Consultants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0701299d-73bc-4607-9277-65f449c9eaca", "a28233e7-3e3e-4600-94fd-11885047209b", "Admin", "ADMIN" },
                    { "c5532d70-068e-417a-bc5d-1b1b1f6f6ed0", "c92def91-ff2c-4808-b180-e0172f43113b", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "35eaf324-131a-490f-9b92-93733070fb1c", 0, "cc5f3219-da00-4207-a82d-3c3911193b84", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEDSJasRAXwnOjElUSO+mmXJWxwy5KqqV0XBNPcSJgknBpl+5xMzPPvIBAO+l1FqgZA==", null, false, "24019d03-1e90-459f-a9bf-dad1ec50199b", false, "admin@gmail.com" },
                    { "e74e5132-4f44-49a3-bd13-d9a0a8fe643a", 0, "b725111d-5c9e-4544-819c-43fe08cddf2f", "employee@gmail.com", true, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEA5nG4r5Ox2our1b7g1Q22pY8Cm0MTqZUgb1sdptBiVFTZqP+5agQjt1bSQ0MSCTjw==", null, false, "8f88106e-31ed-4775-bdc8-e3a3f5ec8e38", false, "employee@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0701299d-73bc-4607-9277-65f449c9eaca", "35eaf324-131a-490f-9b92-93733070fb1c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c5532d70-068e-417a-bc5d-1b1b1f6f6ed0", "e74e5132-4f44-49a3-bd13-d9a0a8fe643a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0701299d-73bc-4607-9277-65f449c9eaca", "35eaf324-131a-490f-9b92-93733070fb1c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c5532d70-068e-417a-bc5d-1b1b1f6f6ed0", "e74e5132-4f44-49a3-bd13-d9a0a8fe643a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0701299d-73bc-4607-9277-65f449c9eaca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5532d70-068e-417a-bc5d-1b1b1f6f6ed0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35eaf324-131a-490f-9b92-93733070fb1c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e74e5132-4f44-49a3-bd13-d9a0a8fe643a");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Consultants");

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
    }
}
