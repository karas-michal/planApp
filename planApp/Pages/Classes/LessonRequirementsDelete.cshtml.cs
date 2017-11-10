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
        private readonly planApp.Data.ApplicationDbContext _context;
        [BindProperty]
        public LessonRequirement LessonRequirement { get; set; }
        [BindProperty]
        public int? ClassID { get; set; }

        public DeleteModel(planApp.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class Class = await _context.Class.SingleOrDefaultAsync(m => m.ID == ClassID);

            if (Class != null)
            {
                Class.Requirements.RemoveAll(m => m.ID == id);
            }

            LessonRequirement = await _context.LessonRequirement.FindAsync(id);

            if (LessonRequirement != null)
            {
                _context.LessonRequirement.Remove(LessonRequirement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Edit", new { id = ClassID });
        }
    }
}
