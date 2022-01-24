using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TicketId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Question = table.Column<string>(type: "TEXT", nullable: true),
                    AssignedTo = table.Column<Guid>(type: "TEXT", nullable: true),
                    CaseClosed = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    UserType = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "UpdatedAt", "UserType", "Username" },
                values: new object[] { new Guid("07d44841-3ee6-4a23-b961-8f7d34b34e3e"), new DateTime(2022, 1, 18, 9, 23, 35, 831, DateTimeKind.Utc).AddTicks(1716), "usertwo@support.org", "dgs7m+tZqBY8cY/fHUnddJ840YgROAQFQEnHUDMV1Q0=", new DateTime(2022, 1, 18, 9, 23, 35, 831, DateTimeKind.Utc).AddTicks(1716), 2, "usertwo" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "UpdatedAt", "UserType", "Username" },
                values: new object[] { new Guid("1547ef23-8228-4ca9-8933-60556ff711d5"), new DateTime(2022, 1, 18, 9, 23, 35, 831, DateTimeKind.Utc).AddTicks(1682), "userone@support.org", "DeLz1xxToYk9dnASFiKlbN5XxMgRmsL2yMA0bOO9bFs=", new DateTime(2022, 1, 18, 9, 23, 35, 831, DateTimeKind.Utc).AddTicks(1682), 2, "userone" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "UpdatedAt", "UserType", "Username" },
                values: new object[] { new Guid("3dac46af-aa41-46ff-8c0d-b7f8caf4125d"), new DateTime(2022, 1, 18, 9, 23, 35, 831, DateTimeKind.Utc).AddTicks(1787), "customertwo@customer.org", "uFAJHMif7jxFxpKpCpyXNiwrf9VJIqGGh/8D7zlJYxI=", new DateTime(2022, 1, 18, 9, 23, 35, 831, DateTimeKind.Utc).AddTicks(1787), 1, "customertwo" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "UpdatedAt", "UserType", "Username" },
                values: new object[] { new Guid("6b47da4e-2e0f-4b4b-8599-8e682394c716"), new DateTime(2022, 1, 18, 9, 23, 35, 831, DateTimeKind.Utc).AddTicks(1746), "customerone@customer.org", "DQ5nUpGIRAjCb2Sfqa/0/OAPj4saH/+b7QKnTLvDdig=", new DateTime(2022, 1, 18, 9, 23, 35, 831, DateTimeKind.Utc).AddTicks(1747), 1, "customerone" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "UpdatedAt", "UserType", "Username" },
                values: new object[] { new Guid("aacfeb4f-4d22-45f9-a396-e9720ce66b17"), new DateTime(2022, 1, 18, 9, 23, 35, 831, DateTimeKind.Utc).AddTicks(1484), "admin@support.org", "7Tl+1DbEbv3Nrn78ExihNJtFQeJ9Ab31H53Ag/O3F8I=", new DateTime(2022, 1, 18, 9, 23, 35, 831, DateTimeKind.Utc).AddTicks(1486), 2, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
