using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleProg.Data.Migrations
{
    public partial class mgr4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PareSubgroups_Schedules_Pare_Id",
                table: "PareSubgroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_PairTimes_Pair_Time_Id",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Semesters_Semester_Id",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Subject_Subject_Id",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Teachers_Teacher_Id",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Pare");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_Teacher_Id",
                table: "Pare",
                newName: "IX_Pare_Teacher_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_Subject_Id",
                table: "Pare",
                newName: "IX_Pare_Subject_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_Semester_Id",
                table: "Pare",
                newName: "IX_Pare_Semester_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_Pair_Time_Id",
                table: "Pare",
                newName: "IX_Pare_Pair_Time_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pare",
                table: "Pare",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pare_PairTimes_Pair_Time_Id",
                table: "Pare",
                column: "Pair_Time_Id",
                principalTable: "PairTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pare_Semesters_Semester_Id",
                table: "Pare",
                column: "Semester_Id",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pare_Subject_Subject_Id",
                table: "Pare",
                column: "Subject_Id",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pare_Teachers_Teacher_Id",
                table: "Pare",
                column: "Teacher_Id",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PareSubgroups_Pare_Pare_Id",
                table: "PareSubgroups",
                column: "Pare_Id",
                principalTable: "Pare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pare_PairTimes_Pair_Time_Id",
                table: "Pare");

            migrationBuilder.DropForeignKey(
                name: "FK_Pare_Semesters_Semester_Id",
                table: "Pare");

            migrationBuilder.DropForeignKey(
                name: "FK_Pare_Subject_Subject_Id",
                table: "Pare");

            migrationBuilder.DropForeignKey(
                name: "FK_Pare_Teachers_Teacher_Id",
                table: "Pare");

            migrationBuilder.DropForeignKey(
                name: "FK_PareSubgroups_Pare_Pare_Id",
                table: "PareSubgroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pare",
                table: "Pare");

            migrationBuilder.RenameTable(
                name: "Pare",
                newName: "Schedules");

            migrationBuilder.RenameIndex(
                name: "IX_Pare_Teacher_Id",
                table: "Schedules",
                newName: "IX_Schedules_Teacher_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Pare_Subject_Id",
                table: "Schedules",
                newName: "IX_Schedules_Subject_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Pare_Semester_Id",
                table: "Schedules",
                newName: "IX_Schedules_Semester_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Pare_Pair_Time_Id",
                table: "Schedules",
                newName: "IX_Schedules_Pair_Time_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PareSubgroups_Schedules_Pare_Id",
                table: "PareSubgroups",
                column: "Pare_Id",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_PairTimes_Pair_Time_Id",
                table: "Schedules",
                column: "Pair_Time_Id",
                principalTable: "PairTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Semesters_Semester_Id",
                table: "Schedules",
                column: "Semester_Id",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Subject_Subject_Id",
                table: "Schedules",
                column: "Subject_Id",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Teachers_Teacher_Id",
                table: "Schedules",
                column: "Teacher_Id",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
