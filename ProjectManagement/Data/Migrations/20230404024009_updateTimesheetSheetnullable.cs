using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class updateTimesheetSheetnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Variation",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidAmount",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "InvoiceAmount",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hours",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ConsultantPay",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Variation",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidAmount",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "InvoiceAmount",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Hours",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ConsultantPay",
                table: "Timesheets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

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
    }
}
