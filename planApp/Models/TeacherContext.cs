using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planApp.Models
{
    public class TeacherContext : DbContext
    {
		public TeacherContext(DbContextOptions<TeacherContext> options) 
			: base(options)
		{

		}

		public DbSet<Teacher> Teacher { get; set; }
    }
}
