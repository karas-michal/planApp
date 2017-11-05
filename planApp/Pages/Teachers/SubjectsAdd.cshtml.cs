using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Pages.Teachers
{
    public class SubjectsAddModel : PageModel
    {
        private readonly planApp.Models.MainContext _context;
        [BindProperty]
        public int? SubjectID { get; set; }
        [BindProperty]
        public int? TeacherID { get; set; }
        public IList<Subject> Subject { get; set; }

        public SubjectsAddModel(planApp.Models.MainContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? teacherId)
        {
            if (teacherId == null)
            {
                return NotFound();
            }

            TeacherID = teacherId;
            Subject = await _context.Subject.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Teacher Teacher = await _context.Teacher.Include("Subjects").SingleOrDefaultAsync(m => m.ID == TeacherID);
            Subject Subject = await _context.Subject.SingleOrDefaultAsync(m => m.ID == SubjectID);

            if (Teacher != null)
            {
                Teacher.Subjects.Add(Subject);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Edit", new { id = TeacherID });
        }
    }
}