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
    public class Create2Model : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;
        [BindProperty]
        public LessonRequirement LessonRequirement { get; set; }
        [BindProperty]
        public int? ClassID { get; set; }
        [BindProperty]
        public int? SubjectID { get; set; }

        public Create2Model(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id, int? subjectId)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassID = id;

            if (subjectId == null)
            {
                return NotFound();
            }

            SubjectID = subjectId;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Class Class = await _context.Class.SingleOrDefaultAsync(m => m.ID == ClassID);
            Subject Subject = await _context.Subject.SingleOrDefaultAsync(m => m.ID == SubjectID);

            if (Class != null && Subject != null)
            {
                LessonRequirement.Subject = Subject;
                _context.LessonRequirement.Add(LessonRequirement);
                Class.Requirements.Add(LessonRequirement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Edit", new { id = ClassID });
        }
    }
}