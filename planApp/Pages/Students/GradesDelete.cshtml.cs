using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Pages.Grades
{
    public class DeleteModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;
        [BindProperty]
        public Grade Grade { get; set; }
        [BindProperty]
        public int? StudentID { get; set; }

        public DeleteModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id, int? studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }

            StudentID = studentId;

            if (id == null)
            {
                return NotFound();
            }

            Grade = await _context.Grade.Include("Subject").SingleOrDefaultAsync(m => m.ID == id);

            if (Grade == null)
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

            Student Student = await _context.Student.SingleOrDefaultAsync(m => m.ID == StudentID);

            if (Student != null)
            {
                Student.Grades.RemoveAll(m => m.ID == id);
            }

            Grade = await _context.Grade.FindAsync(id);

            if (Grade != null)
            {
                _context.Grade.Remove(Grade);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Edit", new { id = StudentID });
        }
    }
}
