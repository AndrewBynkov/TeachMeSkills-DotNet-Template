using Microsoft.EntityFrameworkCore.Migrations;

namespace TeachMeSkills.DataAccessLayer.Migrations
{
    public partial class UpdateFieldPriorityTypeInTodosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                schema: "todo",
                table: "Todos");

            migrationBuilder.AddColumn<int>(
                name: "PriorityType",
                schema: "todo",
                table: "Todos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriorityType",
                schema: "todo",
                table: "Todos");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                schema: "todo",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
