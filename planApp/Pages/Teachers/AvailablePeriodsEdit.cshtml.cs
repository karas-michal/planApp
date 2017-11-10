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
    public class AvailablePeriodsEditModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;

        [BindProperty]
        public AvailablePeriod AvailablePeriod { get; set; }
        [BindProperty]
        public int? TeacherID { get; set; }

        public AvailablePeriodsEditModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id, int? teacherId)
        {
            if (id == null)
            {
                return NotFound();
            }

            AvailablePeriod = await _context.AvailablePeriod.SingleOrDefaultAsync(m => m.ID == id);

            if (AvailablePeriod == null)
            {
                return NotFound();
            }

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

            _context.Attach(AvailablePeriod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return RedirectToPage("./Edit", new { id = TeacherID });
        }
    }
}
