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
    public class StudentsRemoveModel : PageModel
    {
        private readonly planApp.Models.MainContext _context;
        
        [BindProperty]
        public int? ClassID { get; set; }
        [BindProperty]
        public Student Student { get; set; }

        public StudentsRemoveModel(planApp.Models.MainContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id, int? classId)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (classId == null)
            {
                return NotFound();
            }

            Student = await _context.Student.SingleOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }

            ClassID = classId;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ClassID == null)
            {
                return NotFound();
            }

            Class Class = await _context.Class.Include("Students").SingleOrDefaultAsync(m => m.ID == ClassID);

            if (Class != null)
            {
                Class.Students.RemoveAll(m => m.ID == id);
            }

            TeacherSubject TeacherSubject = await _context.TeacherSubject.FindAsync(ClassID, id);

            if(TeacherSubject != null)
            {
                _context.TeacherSubject.Remove(TeacherSubject);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Edit", new { id = ClassID });
        }
    }
}
