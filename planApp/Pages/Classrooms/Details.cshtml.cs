using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Pages.Classrooms
{
    public class DetailsModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;

        public DetailsModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Classroom Classroom { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Classroom = await _context.Classroom.SingleOrDefaultAsync(m => m.ID == id);

            if (Classroom == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
