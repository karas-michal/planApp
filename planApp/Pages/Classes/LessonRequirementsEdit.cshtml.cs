using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Pages.LessonRequirements
{
    public class EditModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;
        [BindProperty]
        public LessonRequirement LessonRequirement { get; set; }
        [BindProperty]
        public int? ClassID { get; set; }

        public EditModel(planApp.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LessonRequirement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return RedirectToPage("./Edit", new { id = ClassID });
        }
    }
}
