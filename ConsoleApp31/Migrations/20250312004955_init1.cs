using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp31.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "topic",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topic", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duration = table.Column<int>(type: "int", nullable: true),
                    topicid = table.Column<int>(name: "topic_id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.id);
                    table.ForeignKey(
                        name: "FK_course_topic_topic_id",
                        column: x => x.topicid,
                        principalTable: "topic",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hirigdate = table.Column<int>(type: "int", nullable: false),
                    insid = table.Column<int>(name: "ins_id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "instructors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    bouns = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    hourrate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deptid = table.Column<int>(name: "dept_id", type: "int", nullable: true),
                    workdeptid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructors", x => x.id);
                    table.ForeignKey(
                        name: "FK_instructors_department_workdeptid",
                        column: x => x.workdeptid,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deptid = table.Column<int>(name: "dept_id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                    table.ForeignKey(
                        name: "FK_students_department_dept_id",
                        column: x => x.deptid,
                        principalTable: "department",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "instcourse",
                columns: table => new
                {
                    insid = table.Column<int>(name: "ins_id", type: "int", nullable: false),
                    crsid = table.Column<int>(name: "crs_id", type: "int", nullable: false),
                    evaluation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    courseid = table.Column<int>(type: "int", nullable: true),
                    instructorid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instcourse", x => new { x.insid, x.crsid });
                    table.ForeignKey(
                        name: "FK_instcourse_course_courseid",
                        column: x => x.courseid,
                        principalTable: "course",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_instcourse_instructors_instructorid",
                        column: x => x.instructorid,
                        principalTable: "instructors",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "stcourse",
                columns: table => new
                {
                    stid = table.Column<int>(name: "st_id", type: "int", nullable: false),
                    crsid = table.Column<int>(name: "crs_id", type: "int", nullable: false),
                    grade = table.Column<int>(type: "int", nullable: true),
                    courseid = table.Column<int>(type: "int", nullable: true),
                    studentid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stcourse", x => new { x.stid, x.crsid });
                    table.ForeignKey(
                        name: "FK_stcourse_course_courseid",
                        column: x => x.courseid,
                        principalTable: "course",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_stcourse_students_studentid",
                        column: x => x.studentid,
                        principalTable: "students",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_course_topic_id",
                table: "course",
                column: "topic_id");

            migrationBuilder.CreateIndex(
                name: "IX_department_ins_id",
                table: "department",
                column: "ins_id",
                unique: true,
                filter: "[ins_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_instcourse_courseid",
                table: "instcourse",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_instcourse_instructorid",
                table: "instcourse",
                column: "instructorid");

            migrationBuilder.CreateIndex(
                name: "IX_instructors_workdeptid",
                table: "instructors",
                column: "workdeptid");

            migrationBuilder.CreateIndex(
                name: "IX_stcourse_courseid",
                table: "stcourse",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_stcourse_studentid",
                table: "stcourse",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_students_dept_id",
                table: "students",
                column: "dept_id");

            migrationBuilder.AddForeignKey(
                name: "FK_department_instructors_ins_id",
                table: "department",
                column: "ins_id",
                principalTable: "instructors",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_department_instructors_ins_id",
                table: "department");

            migrationBuilder.DropTable(
                name: "instcourse");

            migrationBuilder.DropTable(
                name: "stcourse");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "topic");

            migrationBuilder.DropTable(
                name: "instructors");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}
