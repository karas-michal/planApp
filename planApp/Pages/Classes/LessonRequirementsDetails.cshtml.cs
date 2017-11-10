using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using planApp.Models; using planApp.Data;

namespace planApp.Pages.LessonRequirements
{
    public class DetailsModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;
        public LessonRequirement LessonRequirement { get; set; }
        [BindProperty]
        public int? ClassID { get; set; }

        public DetailsModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id, int? classId)
        {
            if (classId == null)
            {
                return NotFound();
            }

            ClassID = classId;

            if (id == null)
            {
                return NotFound();
            }

            LessonRequirement = await _context.LessonRequirement.SingleOrDefaultAsync(m => m.ID == id);

            if (LessonRequirement == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
