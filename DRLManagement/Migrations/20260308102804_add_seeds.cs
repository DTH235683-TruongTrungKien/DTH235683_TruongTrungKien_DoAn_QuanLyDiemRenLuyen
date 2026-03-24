using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDRL.Migrations
{
    /// <inheritdoc />
    public partial class add_seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Managers");

            migrationBuilder.RenameColumn(
                name: "SchoolYear",
                table: "Students",
                newName: "EnrollmentYear");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnrollmentYear",
                table: "Students",
                newName: "SchoolYear");

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Organizers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
