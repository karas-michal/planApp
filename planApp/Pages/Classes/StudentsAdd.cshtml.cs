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
    public class StudentsAddModel : PageModel
    {
        private readonly planApp.Models.MainContext _context;
        [BindProperty]
        public int? StudentID { get; set; }
        [BindProperty]
        public int? ClassID { get; set; }
        public IList<Student> Student { get; set; }

        public StudentsAddModel(planApp.Models.MainContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? classId)
        {
            if (classId == null)
            {
                return NotFound();
            }

            ClassID = classId;
            Student = await _context.Student.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Class Class = await _context.Class.Include("Students").SingleOrDefaultAsync(m => m.ID == ClassID);
            Student Student = await _context.Student.SingleOrDefaultAsync(m => m.ID == StudentID);

            if (Class != null)
            {
                Class.Students.Add(Student);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Edit", new { id = ClassID });
        }
    }
}