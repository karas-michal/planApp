using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using planApp.Models; using planApp.Data;

namespace planApp.Pages.Grades
{
    public class DetailsModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;

        public Grade Grade { get; set; }
        [BindProperty]
        public int? StudentID { get; set; }

        public DetailsModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id, int? studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }

            StudentID = studentId;

            if (id == null)
            {
                return NotFound();
            }

            Grade = await _context.Grade.Include("Subject").SingleOrDefaultAsync(m => m.ID == id);

            if (Grade == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
