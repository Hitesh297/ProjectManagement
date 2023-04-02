using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Data.Migrations
{
    public partial class clearclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_Client_ClientId",
                table: "Consultants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

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

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_Clients_ClientId",
                table: "Consultants",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_Clients_ClientId",
                table: "Consultants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

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

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_Client_ClientId",
                table: "Consultants",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
