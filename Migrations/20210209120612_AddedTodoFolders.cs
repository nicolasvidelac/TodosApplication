using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations
{
    public partial class AddedTodoFolders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todoItems_TodoFolder_FolderId",
                table: "todoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoFolder",
                table: "TodoFolder");

            migrationBuilder.RenameTable(
                name: "TodoFolder",
                newName: "todoFolders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_todoFolders",
                table: "todoFolders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_todoItems_todoFolders_FolderId",
                table: "todoItems",
                column: "FolderId",
                principalTable: "todoFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todoItems_todoFolders_FolderId",
                table: "todoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_todoFolders",
                table: "todoFolders");

            migrationBuilder.RenameTable(
                name: "todoFolders",
                newName: "TodoFolder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoFolder",
                table: "TodoFolder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_todoItems_TodoFolder_FolderId",
                table: "todoItems",
                column: "FolderId",
                principalTable: "TodoFolder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
