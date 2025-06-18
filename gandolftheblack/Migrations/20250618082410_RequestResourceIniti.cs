using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gandolftheblack.Migrations
{
    /// <inheritdoc />
    public partial class RequestResourceIniti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResourceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequesterId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResourceType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Reason = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Duration = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    CreatedUtc = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    NetworkEngineer = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityEngineer = table.Column<string>(type: "TEXT", nullable: true),
                    Manager = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceRequests_Users_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEG5AzP2yorX98h0vuuogTFtaGt4U3maXVu331BzO1mp2uuZhGbjcXliI1nK4DorriA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDzf1dAKpXssBz58uppsn+cm3N/SAhBBcFoqHcIcgrwiOwdFcHWHuDZvNkJ6h8NDCQ==");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceRequests_RequesterId",
                table: "ResourceRequests",
                column: "RequesterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceRequests");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEHt3laFetuThBqPB63Y45kUZZu6yo1hWiLuZ79CJWvsQYKnnoL2ibY5JjOas3nkP4A==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMmlfhkRmUSdXMpyA7WnNM7OWu9WMQm9EKTWBgXnCzme6nhp9s3vm/mfl+JHhauidg==");
        }
    }
}
