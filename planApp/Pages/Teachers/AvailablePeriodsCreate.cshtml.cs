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
        private readonly planApp.Models.MainContext _context;

        public AvailablePeriodsCreateModel(planApp.Models.MainContext context)
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

        [BindProperty]
        public AvailablePeriod AvailablePeriod { get; set; }
        [BindProperty]
        public int? TeacherID { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Teacher Teacher = await _context.Teacher.Include("Availability").Include("Subjects").SingleOrDefaultAsync(m => m.ID == TeacherID);

            if (Teacher != null)
            {
                _context.AvailablePeriod.Add(AvailablePeriod);
                Teacher.Availability.Add(AvailablePeriod);

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}