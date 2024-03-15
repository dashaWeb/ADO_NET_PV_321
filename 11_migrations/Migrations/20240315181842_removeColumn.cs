using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _11_migrations.Migrations
{
    /// <inheritdoc />
    public partial class removeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxPassanger",
                table: "Airplane",
                newName: "Year");

            migrationBuilder.UpdateData(
                table: "Airplane",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Airplane",
                keyColumn: "Id",
                keyValue: 2,
                column: "Year",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Airplane",
                keyColumn: "Id",
                keyValue: 3,
                column: "Year",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Airplane",
                newName: "MaxPassanger");

            migrationBuilder.UpdateData(
                table: "Airplane",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaxPassanger",
                value: 300);

            migrationBuilder.UpdateData(
                table: "Airplane",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaxPassanger",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Airplane",
                keyColumn: "Id",
                keyValue: 3,
                column: "MaxPassanger",
                value: 150);
        }
    }
}
