using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Pages.LessonRequirements
{
    public class DeleteModel : PageModel
    {
        private readonly planApp.Models.MainContext _context;

        public DeleteModel(planApp.Models.MainContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LessonRequirement LessonRequirement { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LessonRequirement = await _context.LessonRequirement.FindAsync(id);

            if (LessonRequirement != null)
            {
                _context.LessonRequirement.Remove(LessonRequirement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
