using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations
{
    public partial class AddfolderAndCompletedToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "todoItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FolderId",
                table: "todoItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TodoFolder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoFolder", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_todoItems_FolderId",
                table: "todoItems",
                column: "FolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_todoItems_TodoFolder_FolderId",
                table: "todoItems",
                column: "FolderId",
                principalTable: "TodoFolder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todoItems_TodoFolder_FolderId",
                table: "todoItems");

            migrationBuilder.DropTable(
                name: "TodoFolder");

            migrationBuilder.DropIndex(
                name: "IX_todoItems_FolderId",
                table: "todoItems");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "todoItems");

            migrationBuilder.DropColumn(
                name: "FolderId",
                table: "todoItems");
        }
    }
}
