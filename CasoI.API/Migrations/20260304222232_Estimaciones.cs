using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasoI.API.Migrations
{
    /// <inheritdoc />
    public partial class Estimaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AsignadoA",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dificultad",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AsignadoA",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Dificultad",
                table: "Task");
        }
    }
}
