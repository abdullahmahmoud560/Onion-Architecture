using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hours = table.Column<int>(type: "int", nullable: true),
                    gpa = table.Column<double>(type: "float", nullable: true),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Student_id);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    course_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "studentSubjects",
                columns: table => new
                {
                    Student_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentSubjects", x => x.Student_id);
                    table.ForeignKey(
                        name: "FK_studentSubjects_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Student_id");
                    table.ForeignKey(
                        name: "FK_studentSubjects_subjects_SubjectCode",
                        column: x => x.SubjectCode,
                        principalTable: "subjects",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjects_StudentId",
                table: "studentSubjects",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjects_SubjectCode",
                table: "studentSubjects",
                column: "SubjectCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentSubjects");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "subjects");
        }
    }
}
