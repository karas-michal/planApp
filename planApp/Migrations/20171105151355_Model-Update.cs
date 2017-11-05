using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace planApp.Migrations
{
    public partial class ModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Class");

            migrationBuilder.AddColumn<string>(
                name: "Letter",
                table: "Class",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Letter",
                table: "Class");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Class",
                nullable: true);
        }
    }
}
