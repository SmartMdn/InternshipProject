using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Halls_EventHallName",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "EventHallName",
                table: "Events",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HallId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Halls_EventHallName",
                table: "Events",
                column: "EventHallName",
                principalTable: "Halls",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Halls_EventHallName",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "EventHallName",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Halls_EventHallName",
                table: "Events",
                column: "EventHallName",
                principalTable: "Halls",
                principalColumn: "Name");
        }
    }
}
