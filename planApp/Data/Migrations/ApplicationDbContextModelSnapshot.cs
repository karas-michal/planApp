using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace planApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
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

				b.Property<int?>("SubjectID");

				b.Property<int>("Value");

				b.HasKey("ID");

				b.HasIndex("StudentID");

				b.HasIndex("SubjectID");

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

				b.HasOne("planApp.Models.Subject", "Subject")
					.WithMany()
					.HasForeignKey("SubjectID");
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

			modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("planApp.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("planApp.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("planApp.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("planApp.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
