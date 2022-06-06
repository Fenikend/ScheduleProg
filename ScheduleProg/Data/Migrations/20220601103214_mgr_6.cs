using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleProg.Data.Migrations
{
    public partial class mgr_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PareId",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Subgr_Number",
                table: "Subgroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_PareId",
                table: "Teachers",
                column: "PareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Pare_PareId",
                table: "Teachers",
                column: "PareId",
                principalTable: "Pare",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Pare_PareId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_PareId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PareId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Subgr_Number",
                table: "Subgroups");
        }
    }
}
