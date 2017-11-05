using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace planApp.Migrations
{
    public partial class TeachersFull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "AvailablePeriod");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "End",
                table: "AvailablePeriod",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Start",
                table: "AvailablePeriod",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "AvailablePeriod");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "AvailablePeriod");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Period",
                table: "AvailablePeriod",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
