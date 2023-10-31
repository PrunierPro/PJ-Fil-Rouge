using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilRougeApi.Migrations
{
    /// <inheritdoc />
    public partial class DefaultUSER : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastName",
                value: "USER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastName",
                value: "User");
        }
    }
}
