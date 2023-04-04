using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class updateTimesheetStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d99140db-3986-4ed7-86d9-6b4efa8c3eea", "8e3e6110-fc31-4643-be02-b56b01c906f5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bf640343-7580-4f06-865f-3dc3d61867c9", "f94969e5-24f6-41d2-9669-c8d6e54f50a0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf640343-7580-4f06-865f-3dc3d61867c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d99140db-3986-4ed7-86d9-6b4efa8c3eea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e3e6110-fc31-4643-be02-b56b01c906f5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94969e5-24f6-41d2-9669-c8d6e54f50a0");

            migrationBuilder.DropColumn(
                name: "AprBilling",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "AugBilling",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "DecBilling",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "FebBilling",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "JanBilling",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "JulBilling",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "JunBilling",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "MarBilling",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "MayBilling",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "NovBilling",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "OctBilling",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "SepBilling",
                table: "Timesheets");

            migrationBuilder.AddColumn<decimal>(
                name: "ConsultantPay",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Hours",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InvoiceAmount",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Variation",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01e78f41-227a-4448-a9db-72144a2e08dd", "6a513919-0edb-48c7-86e3-50c4b2a160ce", "Employee", "EMPLOYEE" },
                    { "9bc4a1cd-5f09-4b07-af10-0535ed07717d", "0ed749cd-4779-4c97-bccd-facaa457b308", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d01b7b18-e70b-4fcf-a563-ada412dee525", 0, "c9a8ddf4-254f-4824-add3-7785dc3064ee", "employee@gmail.com", true, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEARdjmaShyA5xWRzhVBMIUINeBiKU9+xwzBZ/fIWRLtnP/9DJBn9dmNiDGsjIgjLWg==", null, false, "d367e5fb-32df-4162-95b0-c7837c688aee", false, "employee@gmail.com" },
                    { "d946d08e-6337-4ef7-b2ab-13a0f9a00f14", 0, "fb2da963-f867-43db-a33f-3d142919ac95", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEO7tznS8hyFDnj1Uj0KtnI6Iz6an2HVhe7Z9jBUSLJZV5sH4grrBS4yTk7tEbp69Xw==", null, false, "13cdb466-069c-4696-b0e0-d39ec1725091", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "01e78f41-227a-4448-a9db-72144a2e08dd", "d01b7b18-e70b-4fcf-a563-ada412dee525" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9bc4a1cd-5f09-4b07-af10-0535ed07717d", "d946d08e-6337-4ef7-b2ab-13a0f9a00f14" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "01e78f41-227a-4448-a9db-72144a2e08dd", "d01b7b18-e70b-4fcf-a563-ada412dee525" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9bc4a1cd-5f09-4b07-af10-0535ed07717d", "d946d08e-6337-4ef7-b2ab-13a0f9a00f14" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01e78f41-227a-4448-a9db-72144a2e08dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bc4a1cd-5f09-4b07-af10-0535ed07717d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d01b7b18-e70b-4fcf-a563-ada412dee525");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d946d08e-6337-4ef7-b2ab-13a0f9a00f14");

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

            migrationBuilder.AddColumn<decimal>(
                name: "AprBilling",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AugBilling",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DecBilling",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FebBilling",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "JanBilling",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "JulBilling",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "JunBilling",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MarBilling",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MayBilling",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NovBilling",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OctBilling",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SepBilling",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bf640343-7580-4f06-865f-3dc3d61867c9", "6bb31b32-ca6f-409d-a35b-123f6695e410", "Employee", "EMPLOYEE" },
                    { "d99140db-3986-4ed7-86d9-6b4efa8c3eea", "3ad1615d-b88b-4025-b90c-65e74625a31b", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e3e6110-fc31-4643-be02-b56b01c906f5", 0, "70dbd8db-4dab-4597-8a29-d1a24cb92d32", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEFyO4YOkwpetYS+DDON0MsyQ4dAP8RYz9BGZo3nr0SFMjBFomgU5Qw824pPS5/Ik6Q==", null, false, "ce0cca77-f931-4a29-8530-4027d2057edf", false, "admin@gmail.com" },
                    { "f94969e5-24f6-41d2-9669-c8d6e54f50a0", 0, "a3e665a2-7b6d-43b7-bbc8-5e3a0885c998", "employee@gmail.com", true, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEI+0MNox5p2R0ZpSFw2CZO1D3hhK7iU4o4li0bjCM3MT8FcHpa5EA29/0TB2EFLjZg==", null, false, "d37ea67d-83fb-4c17-b4d8-f404e29a4021", false, "employee@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d99140db-3986-4ed7-86d9-6b4efa8c3eea", "8e3e6110-fc31-4643-be02-b56b01c906f5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bf640343-7580-4f06-865f-3dc3d61867c9", "f94969e5-24f6-41d2-9669-c8d6e54f50a0" });
        }
    }
}
