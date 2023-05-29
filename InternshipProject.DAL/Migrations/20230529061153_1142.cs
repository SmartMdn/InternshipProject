using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class _1142 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            _ = migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            _ = migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            _ = migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events");

            _ = migrationBuilder.DropIndex(
                name: "IX_Events_CategoryId",
                table: "Events");

            _ = migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            _ = migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Events");

            _ = migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            _ = migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");
        }
    }
}
