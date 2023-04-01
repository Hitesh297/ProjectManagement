using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeamLeadMemberId",
                table: "Consultants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "RecruiterMemberId",
                table: "Consultants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6dfe806f-05ca-4631-ae27-2c6ce99f5d66", "ea215117-d741-4028-9f1c-9d087abfb250", "Admin", "ADMIN" },
                    { "89148659-c53d-407f-8f41-5075e948c420", "281b56ad-2682-4094-89f0-222b7acc2fa5", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "875bd84b-4c10-4c0d-8a1d-0ccb03da22c6", 0, "3243f9e7-e9fb-4ba1-9459-924b1e41faf2", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEJoP4dl+YI3OhvMbDUZqM/dJ28tnsvmZpqzRsWQuAEEeWj/WLbqjNuiHqRSVcFS14A==", null, false, "a477b2ee-70d6-45be-983e-1d08e3b421a1", false, "admin@gmail.com" },
                    { "913294e3-e00b-4bea-b6c1-f31d163b3778", 0, "c687a243-948a-4763-8492-5527269c5992", "employee@gmail.com", true, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE@GMAIL.COM", "AQAAAAEAACcQAAAAEKQeru9JFyPfYoGiikhcb7GKoRrIciHEcTXv618Wk7XZ50kWdZHv79uLbBl9QuytJA==", null, false, "001d4a0d-1847-460b-9365-0cd73e040101", false, "employee@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6dfe806f-05ca-4631-ae27-2c6ce99f5d66", "875bd84b-4c10-4c0d-8a1d-0ccb03da22c6" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "89148659-c53d-407f-8f41-5075e948c420", "913294e3-e00b-4bea-b6c1-f31d163b3778" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6dfe806f-05ca-4631-ae27-2c6ce99f5d66", "875bd84b-4c10-4c0d-8a1d-0ccb03da22c6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "89148659-c53d-407f-8f41-5075e948c420", "913294e3-e00b-4bea-b6c1-f31d163b3778" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dfe806f-05ca-4631-ae27-2c6ce99f5d66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89148659-c53d-407f-8f41-5075e948c420");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "875bd84b-4c10-4c0d-8a1d-0ccb03da22c6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "913294e3-e00b-4bea-b6c1-f31d163b3778");

            migrationBuilder.AlterColumn<int>(
                name: "TeamLeadMemberId",
                table: "Consultants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "RecruiterMemberId",
                table: "Consultants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 0);
        }
    }
}
