using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace planApp.Migrations
{
    public partial class ModelUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Classroom");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Classroom",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Classroom");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Classroom",
                nullable: true);
        }
    }
}
