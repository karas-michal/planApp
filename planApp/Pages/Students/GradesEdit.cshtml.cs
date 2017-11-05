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
    public class EditModel : PageModel
    {
        private readonly planApp.Models.MainContext _context;

        [BindProperty]
        public Grade Grade { get; set; }
        [BindProperty]
        public int? StudentID { get; set; }

        public EditModel(planApp.Models.MainContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Grade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return RedirectToPage("./Edit", new { id = StudentID });
        }
    }
}
