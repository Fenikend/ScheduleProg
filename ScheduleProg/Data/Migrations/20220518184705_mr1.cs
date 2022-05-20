using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleProg.Data.Migrations
{
    public partial class mr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Groups_Group_Id",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_Group_Id",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Group_Id",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Students",
                newName: "Subgroup_Id");

            migrationBuilder.AddColumn<int>(
                name: "Potok_Id",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Potoks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Potok_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potoks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subgroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subgr_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subgroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subgroups_Groups_Group_Id",
                        column: x => x.Group_Id,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PareSubgroups",
                columns: table => new
                {
                    Pare_Id = table.Column<int>(type: "int", nullable: false),
                    Subgroup_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PareSubgroups", x => new { x.Pare_Id, x.Subgroup_Id });
                    table.ForeignKey(
                        name: "FK_PareSubgroups_Schedules_Pare_Id",
                        column: x => x.Pare_Id,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PareSubgroups_Subgroups_Subgroup_Id",
                        column: x => x.Subgroup_Id,
                        principalTable: "Subgroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Subgroup_Id",
                table: "Students",
                column: "Subgroup_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Potok_Id",
                table: "Groups",
                column: "Potok_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PareSubgroups_Subgroup_Id",
                table: "PareSubgroups",
                column: "Subgroup_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subgroups_Group_Id",
                table: "Subgroups",
                column: "Group_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Potoks_Potok_Id",
                table: "Groups",
                column: "Potok_Id",
                principalTable: "Potoks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subgroups_Subgroup_Id",
                table: "Students",
                column: "Subgroup_Id",
                principalTable: "Subgroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Potoks_Potok_Id",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subgroups_Subgroup_Id",
                table: "Students");

            migrationBuilder.DropTable(
                name: "PareSubgroups");

            migrationBuilder.DropTable(
                name: "Potoks");

            migrationBuilder.DropTable(
                name: "Subgroups");

            migrationBuilder.DropIndex(
                name: "IX_Students_Subgroup_Id",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Groups_Potok_Id",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Potok_Id",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "Subgroup_Id",
                table: "Students",
                newName: "User_Id");

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Group_Id",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Group_Id",
                table: "Schedules",
                column: "Group_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Groups_Group_Id",
                table: "Schedules",
                column: "Group_Id",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
