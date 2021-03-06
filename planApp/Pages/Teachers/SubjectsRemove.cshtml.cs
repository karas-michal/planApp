using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Pages.Teachers
{
    public class SubjectsRemoveModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;
        
        [BindProperty]
        public int? TeacherID { get; set; }
        [BindProperty]
        public Subject Subject { get; set; }

        public SubjectsRemoveModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id, int? teacherId)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (teacherId == null)
            {
                return NotFound();
            }

            Subject = await _context.Subject.SingleOrDefaultAsync(m => m.ID == id);

            if (Subject == null)
            {
                return NotFound();
            }

            TeacherID = teacherId;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (TeacherID == null)
            {
                return NotFound();
            }

            Teacher Teacher = await _context.Teacher.Include("Subjects").Include("Subjects.Subject").Include("Subjects.Teacher").SingleOrDefaultAsync(m => m.ID == TeacherID);

            if (Teacher != null)
            {
                Teacher.Subjects.RemoveAll(m => m.Subject.ID == id);
            }

            TeacherSubject TeacherSubject = await _context.TeacherSubject.FindAsync(TeacherID, id);

            if(TeacherSubject != null)
            {
                _context.TeacherSubject.Remove(TeacherSubject);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Edit", new { id = TeacherID });
        }
    }
}
