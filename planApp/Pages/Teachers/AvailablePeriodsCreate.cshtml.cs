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
    public class AvailablePeriodsCreateModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;

        [BindProperty]
        public AvailablePeriod AvailablePeriod { get; set; }
        [BindProperty]
        public int? TeacherID { get; set; }

        public AvailablePeriodsCreateModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? teacherId)
        {
            if (teacherId == null)
            {
                return NotFound();
            }

            TeacherID = teacherId;
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Teacher Teacher = await _context.Teacher.Include("Availability").SingleOrDefaultAsync(m => m.ID == TeacherID);

            if (Teacher != null)
            {
                _context.AvailablePeriod.Add(AvailablePeriod);
                Teacher.Availability.Add(AvailablePeriod);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Edit", new { id = TeacherID });
        }
    }
}