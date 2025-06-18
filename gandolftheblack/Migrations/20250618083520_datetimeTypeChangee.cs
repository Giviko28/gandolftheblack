using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gandolftheblack.Migrations
{
    /// <inheritdoc />
    public partial class datetimeTypeChangee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
