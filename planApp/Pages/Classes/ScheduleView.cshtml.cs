using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Pages.Classes
{
    public class ScheduleViewModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;
        public Class Class { get; set; }
        public List<Lesson> Schedule;

        public ScheduleViewModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class = await _context.Class
                .Include("Students")
                .Include("Requirements")
                .SingleOrDefaultAsync(m => m.ID == id);

            if (Class == null)
            {
                return NotFound();
            }

            Schedule = _context.Lesson.Include("Class").Where(l => l.Class == Class)
                .Include("Teacher")
                .Include("Subject")
                .Include("Classroom")
                .OrderBy(l => l.Day)
                .ThenBy(l => l.Hour)
                .ToList();

            if (Schedule == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
