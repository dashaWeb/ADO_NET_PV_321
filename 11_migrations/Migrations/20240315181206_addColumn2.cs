using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _11_migrations.Migrations
{
    /// <inheritdoc />
    public partial class addColumn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Airplane",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Airplane",
                keyColumn: "Id",
                keyValue: 1,
                column: "Test",
                value: "Test");

            migrationBuilder.UpdateData(
                table: "Airplane",
                keyColumn: "Id",
                keyValue: 2,
                column: "Test",
                value: "Test");

            migrationBuilder.UpdateData(
                table: "Airplane",
                keyColumn: "Id",
                keyValue: 3,
                column: "Test",
                value: "Test");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Airplane");
        }
    }
}
