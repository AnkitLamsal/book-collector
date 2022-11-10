using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookcollector.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCollection_Books_bookId",
                table: "BookCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCollection_Collections_collectionId",
                table: "BookCollection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCollection",
                table: "BookCollection");

            migrationBuilder.RenameTable(
                name: "BookCollection",
                newName: "BookCollections");

            migrationBuilder.RenameIndex(
                name: "IX_BookCollection_collectionId",
                table: "BookCollections",
                newName: "IX_BookCollections_collectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCollections",
                table: "BookCollections",
                columns: new[] { "bookId", "collectionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookCollections_Books_bookId",
                table: "BookCollections",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCollections_Collections_collectionId",
                table: "BookCollections",
                column: "collectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCollections_Books_bookId",
                table: "BookCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCollections_Collections_collectionId",
                table: "BookCollections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCollections",
                table: "BookCollections");

            migrationBuilder.RenameTable(
                name: "BookCollections",
                newName: "BookCollection");

            migrationBuilder.RenameIndex(
                name: "IX_BookCollections_collectionId",
                table: "BookCollection",
                newName: "IX_BookCollection_collectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCollection",
                table: "BookCollection",
                columns: new[] { "bookId", "collectionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookCollection_Books_bookId",
                table: "BookCollection",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCollection_Collections_collectionId",
                table: "BookCollection",
                column: "collectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
