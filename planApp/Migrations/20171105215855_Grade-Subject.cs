using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace planApp.Migrations
{
    public partial class GradeSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "Grade",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grade_SubjectID",
                table: "Grade",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Subject_SubjectID",
                table: "Grade",
                column: "SubjectID",
                principalTable: "Subject",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Subject_SubjectID",
                table: "Grade");

            migrationBuilder.DropIndex(
                name: "IX_Grade_SubjectID",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "Grade");
        }
    }
}
