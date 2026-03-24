using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDRL.Migrations
{
    /// <inheritdoc />
    public partial class update_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appeals_Managers_ManagerId",
                table: "Appeals");

            migrationBuilder.DropForeignKey(
                name: "FK_Appeals_Semesters_SemesterId",
                table: "Appeals");

            migrationBuilder.DropForeignKey(
                name: "FK_Appeals_Students_StudentId",
                table: "Appeals");

            migrationBuilder.DropForeignKey(
                name: "FK_Confirms_Managers_ManagerId",
                table: "Confirms");

            migrationBuilder.DropForeignKey(
                name: "FK_Confirms_Students_StudentId",
                table: "Confirms");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Managers_ManagerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsRegistrations_Events_EventId",
                table: "EventsRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventsRegistrations_Students_StudentId",
                table: "EventsRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Evidences_Managers_ManagerUserId",
                table: "Evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_Evidences_Students_StudentId",
                table: "Evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_PointDetails_Students_StudentId",
                table: "PointDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Semesters_SemesterId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SemesterId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Evidences_ManagerUserId",
                table: "Evidences");

            migrationBuilder.DropIndex(
                name: "IX_Appeals_ManagerId",
                table: "Appeals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventsRegistrations",
                table: "EventsRegistrations");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "TotalEvents",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "ManagerUserId",
                table: "Evidences");

            migrationBuilder.DropColumn(
                name: "AddPoint",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "RemovePoint",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Appeals");

            migrationBuilder.RenameTable(
                name: "EventsRegistrations",
                newName: "EventRegistrations");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Students",
                newName: "SchoolYear");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "PointDetails",
                newName: "StudentUserId");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Organizers",
                newName: "AssignedDate");

            migrationBuilder.RenameColumn(
                name: "OrganizerCode",
                table: "Organizers",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Evidences",
                newName: "StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Evidences_StudentId",
                table: "Evidences",
                newName: "IX_Evidences_StudentUserId");

            migrationBuilder.RenameColumn(
                name: "OrganizerId",
                table: "Events",
                newName: "OrganizerUserId");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Events",
                newName: "ManagerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_OrganizerId",
                table: "Events",
                newName: "IX_Events_OrganizerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_ManagerId",
                table: "Events",
                newName: "IX_Events_ManagerUserId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Confirms",
                newName: "StudentUserId");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Confirms",
                newName: "ManagerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Confirms_StudentId",
                table: "Confirms",
                newName: "IX_Confirms_StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Confirms_ManagerId",
                table: "Confirms",
                newName: "IX_Confirms_ManagerUserId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Appeals",
                newName: "StudentUserId");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "Appeals",
                newName: "ManagerUserId");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Appeals",
                newName: "Response");

            migrationBuilder.RenameIndex(
                name: "IX_Appeals_StudentId",
                table: "Appeals",
                newName: "IX_Appeals_StudentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Appeals_SemesterId",
                table: "Appeals",
                newName: "IX_Appeals_ManagerUserId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "EventRegistrations",
                newName: "PointCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_EventsRegistrations_StudentId",
                table: "EventRegistrations",
                newName: "IX_EventRegistrations_PointCategoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "GPA",
                table: "Students",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GraduationYear",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StudentClassId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Semesters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PointCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationExpired",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AssignedDate",
                table: "Admins",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StudentUserId",
                table: "EventRegistrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventRegistrations",
                table: "EventRegistrations",
                columns: new[] { "EventId", "StudentUserId" });

            migrationBuilder.CreateTable(
                name: "EventDetails",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    PointCategoryId = table.Column<int>(type: "int", nullable: false),
                    AddPoint = table.Column<double>(type: "float", nullable: false),
                    RemovePoint = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetails", x => new { x.EventId, x.PointCategoryId });
                    table.ForeignKey(
                        name: "FK_EventDetails_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDetails_PointCategories_PointCategoryId",
                        column: x => x.PointCategoryId,
                        principalTable: "PointCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

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
                name: "Majors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Majors_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MajorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentClasses_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
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
                name: "IX_Students_StudentClassId",
                table: "Students",
                column: "StudentClassId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_StudentUserId",
                table: "EventRegistrations",
                column: "StudentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_PointCategoryId",
                table: "EventDetails",
                column: "PointCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventFaculty_EventsId",
                table: "EventFaculty",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventStudentClass_EventsId",
                table: "EventStudentClass",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_Majors_FacultyId",
                table: "Majors",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_MajorId",
                table: "StudentClasses",
                column: "MajorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_Managers_ManagerUserId",
                table: "Appeals",
                column: "ManagerUserId",
                principalTable: "Managers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_Students_StudentUserId",
                table: "Appeals",
                column: "StudentUserId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Confirms_Managers_ManagerUserId",
                table: "Confirms",
                column: "ManagerUserId",
                principalTable: "Managers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Confirms_Students_StudentUserId",
                table: "Confirms",
                column: "StudentUserId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_Events_EventId",
                table: "EventRegistrations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_PointCategories_PointCategoryId",
                table: "EventRegistrations",
                column: "PointCategoryId",
                principalTable: "PointCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_Students_StudentUserId",
                table: "EventRegistrations",
                column: "StudentUserId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Managers_ManagerUserId",
                table: "Events",
                column: "ManagerUserId",
                principalTable: "Managers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerUserId",
                table: "Events",
                column: "OrganizerUserId",
                principalTable: "Organizers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evidences_Students_StudentUserId",
                table: "Evidences",
                column: "StudentUserId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PointDetails_Students_StudentUserId",
                table: "PointDetails",
                column: "StudentUserId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentClasses_StudentClassId",
                table: "Students",
                column: "StudentClassId",
                principalTable: "StudentClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appeals_Managers_ManagerUserId",
                table: "Appeals");

            migrationBuilder.DropForeignKey(
                name: "FK_Appeals_Students_StudentUserId",
                table: "Appeals");

            migrationBuilder.DropForeignKey(
                name: "FK_Confirms_Managers_ManagerUserId",
                table: "Confirms");

            migrationBuilder.DropForeignKey(
                name: "FK_Confirms_Students_StudentUserId",
                table: "Confirms");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_Events_EventId",
                table: "EventRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_PointCategories_PointCategoryId",
                table: "EventRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_Students_StudentUserId",
                table: "EventRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Managers_ManagerUserId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerUserId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Evidences_Students_StudentUserId",
                table: "Evidences");

            migrationBuilder.DropForeignKey(
                name: "FK_PointDetails_Students_StudentUserId",
                table: "PointDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentClasses_StudentClassId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "EventDetails");

            migrationBuilder.DropTable(
                name: "EventFaculty");

            migrationBuilder.DropTable(
                name: "EventStudentClass");

            migrationBuilder.DropTable(
                name: "StudentClasses");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentClassId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventRegistrations",
                table: "EventRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_StudentUserId",
                table: "EventRegistrations");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GraduationYear",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "PointCategories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "RegistrationExpired",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AssignedDate",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "StudentUserId",
                table: "EventRegistrations");

            migrationBuilder.RenameTable(
                name: "EventRegistrations",
                newName: "EventsRegistrations");

            migrationBuilder.RenameColumn(
                name: "SchoolYear",
                table: "Students",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "StudentUserId",
                table: "PointDetails",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Organizers",
                newName: "OrganizerCode");

            migrationBuilder.RenameColumn(
                name: "AssignedDate",
                table: "Organizers",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "StudentUserId",
                table: "Evidences",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Evidences_StudentUserId",
                table: "Evidences",
                newName: "IX_Evidences_StudentId");

            migrationBuilder.RenameColumn(
                name: "OrganizerUserId",
                table: "Events",
                newName: "OrganizerId");

            migrationBuilder.RenameColumn(
                name: "ManagerUserId",
                table: "Events",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_OrganizerUserId",
                table: "Events",
                newName: "IX_Events_OrganizerId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_ManagerUserId",
                table: "Events",
                newName: "IX_Events_ManagerId");

            migrationBuilder.RenameColumn(
                name: "StudentUserId",
                table: "Confirms",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "ManagerUserId",
                table: "Confirms",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Confirms_StudentUserId",
                table: "Confirms",
                newName: "IX_Confirms_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Confirms_ManagerUserId",
                table: "Confirms",
                newName: "IX_Confirms_ManagerId");

            migrationBuilder.RenameColumn(
                name: "StudentUserId",
                table: "Appeals",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Response",
                table: "Appeals",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "ManagerUserId",
                table: "Appeals",
                newName: "SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Appeals_StudentUserId",
                table: "Appeals",
                newName: "IX_Appeals_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Appeals_ManagerUserId",
                table: "Appeals",
                newName: "IX_Appeals_SemesterId");

            migrationBuilder.RenameColumn(
                name: "PointCategoryId",
                table: "EventsRegistrations",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_EventRegistrations_PointCategoryId",
                table: "EventsRegistrations",
                newName: "IX_EventsRegistrations_StudentId");

            migrationBuilder.AlterColumn<string>(
                name: "Birthday",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "GPA",
                table: "Students",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SemesterId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Organizers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TotalEvents",
                table: "Organizers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ManagerUserId",
                table: "Evidences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AddPoint",
                table: "Events",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RemovePoint",
                table: "Events",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Appeals",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventsRegistrations",
                table: "EventsRegistrations",
                columns: new[] { "EventId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_SemesterId",
                table: "Students",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Evidences_ManagerUserId",
                table: "Evidences",
                column: "ManagerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_ManagerId",
                table: "Appeals",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_Managers_ManagerId",
                table: "Appeals",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_Semesters_SemesterId",
                table: "Appeals",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_Students_StudentId",
                table: "Appeals",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Confirms_Managers_ManagerId",
                table: "Confirms",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Confirms_Students_StudentId",
                table: "Confirms",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Managers_ManagerId",
                table: "Events",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerId",
                table: "Events",
                column: "OrganizerId",
                principalTable: "Organizers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsRegistrations_Events_EventId",
                table: "EventsRegistrations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventsRegistrations_Students_StudentId",
                table: "EventsRegistrations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evidences_Managers_ManagerUserId",
                table: "Evidences",
                column: "ManagerUserId",
                principalTable: "Managers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evidences_Students_StudentId",
                table: "Evidences",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PointDetails_Students_StudentId",
                table: "PointDetails",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Semesters_SemesterId",
                table: "Students",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id");
        }
    }
}
