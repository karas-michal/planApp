using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using planApp.Models;
using planApp.Data;

namespace planApp.Pages.Register
{
    public class ViewModel : PageModel
    {
		private readonly planApp.Data.ApplicationDbContext _context;
		public IList<Student> Student { get; set; }
		public IList<Subject> Subject { get; set; }
		public IList<Grade> Grade { get; set; }
		public ViewModel(planApp.Data.ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task OnGetAsync()
		{
			Student = await _context.Student.Include("Grades").Include("Grades.Subject").ToListAsync();
			Subject = await _context.Subject.ToListAsync();
			Grade = await _context.Grade.ToListAsync();
		}
	}
}