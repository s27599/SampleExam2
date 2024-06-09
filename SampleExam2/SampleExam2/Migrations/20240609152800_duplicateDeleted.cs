using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleExam2.Migrations
{
    /// <inheritdoc />
    public partial class duplicateDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAlbum",
                table: "Songs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAlbum",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
