using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFlow.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class secound : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpEmailId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmpPassowrd",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpEmailId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmpPassowrd",
                table: "Employees");
        }
    }
}
