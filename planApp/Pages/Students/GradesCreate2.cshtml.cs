using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Pages.Grades
{
    public class Create2Model : PageModel
    {
        private readonly planApp.Models.MainContext _context;
        [BindProperty]
        public Grade Grade { get; set; }
        [BindProperty]
        public int? StudentID { get; set; }
        [BindProperty]
        public int? SubjectID { get; set; }

        public Create2Model(planApp.Models.MainContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id, int? subjectId)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentID = id;

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

            Student Student = await _context.Student.SingleOrDefaultAsync(m => m.ID == StudentID);
            Subject Subject = await _context.Subject.SingleOrDefaultAsync(m => m.ID == SubjectID);

            if (Subject != null && Student != null)
            {
                Grade.Subject = Subject;
                _context.Grade.Add(Grade);
                Student.Grades.Add(Grade);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Edit", new { id = StudentID });
        }
    }
}