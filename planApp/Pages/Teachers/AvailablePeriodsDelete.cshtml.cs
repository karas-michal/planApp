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
    public class AvailablePeriodsDeleteModel : PageModel
    {
        private readonly planApp.Models.MainContext _context;

        public AvailablePeriodsDeleteModel(planApp.Models.MainContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AvailablePeriod AvailablePeriod { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AvailablePeriod = await _context.AvailablePeriod.FindAsync(id);

            if (AvailablePeriod != null)
            {
                _context.AvailablePeriod.Remove(AvailablePeriod);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Edit");
        }
    }
}
