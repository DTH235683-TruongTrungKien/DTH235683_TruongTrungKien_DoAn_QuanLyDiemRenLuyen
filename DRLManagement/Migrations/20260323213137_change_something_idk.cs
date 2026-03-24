using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDRL.Migrations
{
    /// <inheritdoc />
    public partial class change_something_idk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventFaculty");

            migrationBuilder.DropTable(
                name: "EventStudentClass");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "StudentClasses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Faculties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_EventId",
                table: "StudentClasses",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_EventId",
                table: "Faculties",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Events_EventId",
                table: "Faculties",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Events_EventId",
                table: "StudentClasses",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Events_EventId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Events_EventId",
                table: "StudentClasses");

            migrationBuilder.DropIndex(
                name: "IX_StudentClasses_EventId",
                table: "StudentClasses");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_EventId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "StudentClasses");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Faculties");

            migrationBuilder.CreateTable(
                name: "EventFaculty",
                columns: table => new
                {
                    AllowFacultiesId = table.Column<int>(type: "int", nullable: false),
                    EventsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventFaculty", x => new { x.AllowFacultiesId, x.EventsId });
                    table.ForeignKey(
                        name: "FK_EventFaculty_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventFaculty_Faculties_AllowFacultiesId",
                        column: x => x.AllowFacultiesId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventStudentClass",
                columns: table => new
                {
                    AllowClassesId = table.Column<int>(type: "int", nullable: false),
                    EventsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStudentClass", x => new { x.AllowClassesId, x.EventsId });
                    table.ForeignKey(
                        name: "FK_EventStudentClass_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventStudentClass_StudentClasses_AllowClassesId",
                        column: x => x.AllowClassesId,
                        principalTable: "StudentClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventFaculty_EventsId",
                table: "EventFaculty",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventStudentClass_EventsId",
                table: "EventStudentClass",
                column: "EventsId");
        }
    }
}
