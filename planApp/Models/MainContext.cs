using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
	public class MainContext : DbContext
	{
		public MainContext(DbContextOptions<MainContext> options) 
			: base(options)
		{

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
	}
}
