using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp31.Migrations
{
    /// <inheritdoc />
    public partial class createview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view departmentstudent
                                     with incryption

                                     as
                               select d.dept-id,s.fname
                                   from student s,department d
                                      where d.dept-id=s.id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql(@"drop view departmentstudent");
        }
    }
}
