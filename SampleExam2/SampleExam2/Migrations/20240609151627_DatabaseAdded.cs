using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleExam2.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    IdLabel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.IdLabel);
                });

            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    idMusician = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.idMusician);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LabelIdLabel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Albums_Labels_LabelIdLabel",
                        column: x => x.LabelIdLabel,
                        principalTable: "Labels",
                        principalColumn: "IdLabel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    IdSong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    IdAlbum = table.Column<int>(type: "int", nullable: false),
                    AlbumIdAlbum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.IdSong);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumIdAlbum",
                        column: x => x.AlbumIdAlbum,
                        principalTable: "Albums",
                        principalColumn: "IdAlbum");
                });

            migrationBuilder.CreateTable(
                name: "MusicianSong",
                columns: table => new
                {
                    MusiciansidMusician = table.Column<int>(type: "int", nullable: false),
                    SongsIdSong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianSong", x => new { x.MusiciansidMusician, x.SongsIdSong });
                    table.ForeignKey(
                        name: "FK_MusicianSong_Musicians_MusiciansidMusician",
                        column: x => x.MusiciansidMusician,
                        principalTable: "Musicians",
                        principalColumn: "idMusician",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicianSong_Songs_SongsIdSong",
                        column: x => x.SongsIdSong,
                        principalTable: "Songs",
                        principalColumn: "IdSong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_LabelIdLabel",
                table: "Albums",
                column: "LabelIdLabel");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianSong_SongsIdSong",
                table: "MusicianSong",
                column: "SongsIdSong");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumIdAlbum",
                table: "Songs",
                column: "AlbumIdAlbum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicianSong");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Labels");
        }
    }
}
