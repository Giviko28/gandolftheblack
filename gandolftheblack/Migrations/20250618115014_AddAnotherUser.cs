using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gandolftheblack.Migrations
{
    /// <inheritdoc />
    public partial class AddAnotherUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENVfSw7jxNf2/xGaW4nOD3lV3lY81nikKu0HQSYJTzhwJMNVSDTnSZIXgonXNiUR/w==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEJhXnk8ILEHgwgHgJiEy9zXi9hHohY/AF0mAvGqoAMa3CMlywlchgti2ChZH6ZPPQ==");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role" },
                values: new object[] { 3, "user@gmail.com", "AQAAAAIAAYagAAAAEIegujIKMZI4h/ASuODw/65fXiiZQBgoQXZS5OOzRie8z+aNqVjpDKpAF//s4ytmaA==", "User" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEChsvmxdZq9vCWsltGQs7OGCp3IRsufjZFiL8b1ZwZ0rKUAPkpAN+DSpXG5a221VA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGwuEJxeSg3N5dMAi53vZPpOtVwrrc28feKMhYC2pOaxXk/fdnP5+zG/2dURZUn/zQ==");
        }
    }
}
