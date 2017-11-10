using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
			builder.Entity<TeacherSubject>().HasKey(m => new { m.TeacherID, m.SubjectID });
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);
		}

		public DbSet<AvailablePeriod> AvailablePeriod { get; set; }
		public DbSet<Class> Class { get; set; }
		public DbSet<Classroom> Classroom { get; set; }
		public DbSet<Grade> Grade { get; set; }
		public DbSet<Lesson> Lesson { get; set; }
		public DbSet<LessonRequirement> LessonRequirement { get; set; }
		public DbSet<Student> Student { get; set; }
		public DbSet<Subject> Subject { get; set; }
		public DbSet<Teacher> Teacher { get; set; }
		public DbSet<TeacherSubject> TeacherSubject { get; set; }
	}
}
