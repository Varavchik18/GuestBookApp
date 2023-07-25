using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class RenamedNotesIntoComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    IdComment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateTimeCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateTimeUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AuthorIdAuthor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.IdComment);
                    table.ForeignKey(
                        name: "FK_Comments_Authors_AuthorIdAuthor",
                        column: x => x.AuthorIdAuthor,
                        principalTable: "Authors",
                        principalColumn: "IdAuthor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorIdAuthor",
                table: "Comments",
                column: "AuthorIdAuthor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    IdNote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorIdAuthor = table.Column<int>(type: "int", nullable: false),
                    DateTimeCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateTimeUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.IdNote);
                    table.ForeignKey(
                        name: "FK_Notes_Authors_AuthorIdAuthor",
                        column: x => x.AuthorIdAuthor,
                        principalTable: "Authors",
                        principalColumn: "IdAuthor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_AuthorIdAuthor",
                table: "Notes",
                column: "AuthorIdAuthor");
        }
    }
}
