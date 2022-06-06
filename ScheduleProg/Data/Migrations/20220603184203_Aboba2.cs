﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleProg.Data.Migrations
{
    public partial class Aboba2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User_Id",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Students");
        }
    }
}
