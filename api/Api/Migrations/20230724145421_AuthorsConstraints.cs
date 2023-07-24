using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AuthorsConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Authors_AuthorId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Notes",
                newName: "AuthorIdAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_AuthorId",
                table: "Notes",
                newName: "IX_Notes_AuthorIdAuthor");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "IdAuthor");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Authors",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Authors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Authors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Authors_AuthorIdAuthor",
                table: "Notes",
                column: "AuthorIdAuthor",
                principalTable: "Authors",
                principalColumn: "IdAuthor",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Authors_AuthorIdAuthor",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "AuthorIdAuthor",
                table: "Notes",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_AuthorIdAuthor",
                table: "Notes",
                newName: "IX_Notes_AuthorId");

            migrationBuilder.RenameColumn(
                name: "IdAuthor",
                table: "Authors",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Authors_AuthorId",
                table: "Notes",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
