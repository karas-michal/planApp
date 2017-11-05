﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using planApp.Models;
using System;

namespace planApp.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20171105211549_Teacher-Subject-Many-To-Many")]
    partial class TeacherSubjectManyToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("planApp.Models.AvailablePeriod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Day");

                    b.Property<TimeSpan>("End");

                    b.Property<TimeSpan>("Start");

                    b.Property<int?>("TeacherID");

                    b.HasKey("ID");

                    b.HasIndex("TeacherID");

                    b.ToTable("AvailablePeriod");
                });

            modelBuilder.Entity("planApp.Models.Class", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Letter")
                        .HasMaxLength(1);

                    b.Property<int>("Year");

                    b.HasKey("ID");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("planApp.Models.Classroom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Number");

                    b.HasKey("ID");

                    b.ToTable("Classroom");
                });

            modelBuilder.Entity("planApp.Models.Grade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("StudentID");

                    b.Property<int>("Value");

                    b.HasKey("ID");

                    b.HasIndex("StudentID");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("planApp.Models.Lesson", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClassID");

                    b.Property<int?>("ClassroomID");

                    b.Property<int>("Day");

                    b.Property<int>("Hour");

                    b.Property<int?>("SubjectID");

                    b.Property<int?>("TeacherID");

                    b.HasKey("ID");

                    b.HasIndex("ClassID");

                    b.HasIndex("ClassroomID");

                    b.HasIndex("SubjectID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("planApp.Models.LessonRequirement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClassID");

                    b.Property<int>("Hours");

                    b.Property<int?>("SubjectID");

                    b.HasKey("ID");

                    b.HasIndex("ClassID");

                    b.HasIndex("SubjectID");

                    b.ToTable("LessonRequirement");
                });

            modelBuilder.Entity("planApp.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClassID");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.HasIndex("ClassID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("planApp.Models.Subject", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("planApp.Models.Teacher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("planApp.Models.TeacherSubject", b =>
                {
                    b.Property<int>("TeacherID");

                    b.Property<int>("SubjectID");

                    b.HasKey("TeacherID", "SubjectID");

                    b.HasIndex("SubjectID");

                    b.ToTable("TeacherSubject");
                });

            modelBuilder.Entity("planApp.Models.AvailablePeriod", b =>
                {
                    b.HasOne("planApp.Models.Teacher")
                        .WithMany("Availability")
                        .HasForeignKey("TeacherID");
                });

            modelBuilder.Entity("planApp.Models.Grade", b =>
                {
                    b.HasOne("planApp.Models.Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentID");
                });

            modelBuilder.Entity("planApp.Models.Lesson", b =>
                {
                    b.HasOne("planApp.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassID");

                    b.HasOne("planApp.Models.Classroom", "Classroom")
                        .WithMany()
                        .HasForeignKey("ClassroomID");

                    b.HasOne("planApp.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID");

                    b.HasOne("planApp.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherID");
                });

            modelBuilder.Entity("planApp.Models.LessonRequirement", b =>
                {
                    b.HasOne("planApp.Models.Class")
                        .WithMany("Requirements")
                        .HasForeignKey("ClassID");

                    b.HasOne("planApp.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID");
                });

            modelBuilder.Entity("planApp.Models.Student", b =>
                {
                    b.HasOne("planApp.Models.Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassID");
                });

            modelBuilder.Entity("planApp.Models.TeacherSubject", b =>
                {
                    b.HasOne("planApp.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("planApp.Models.Teacher", "Teacher")
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
