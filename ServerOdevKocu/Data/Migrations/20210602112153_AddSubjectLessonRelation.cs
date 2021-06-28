using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerOdevKocu.Migrations
{
    public partial class AddSubjectLessonRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Subjects",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_LessonId",
                table: "Subjects",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Lesson_LessonId",
                table: "Subjects",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Lesson_LessonId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_LessonId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Subjects");
        }
    }
}
