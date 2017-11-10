using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using planApp.Models; using planApp.Data;

namespace planApp.Pages.Teachers
{
    public class DetailsModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;

        public Teacher Teacher { get; set; }

        public DetailsModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teacher = await _context.Teacher.Include("Availability").Include("Subjects").Include("Subjects.Subject").Include("Subjects.Teacher").SingleOrDefaultAsync(m => m.ID == id);

            if (Teacher == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
