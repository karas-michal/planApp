using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Pages.AvailablePeriods
{
    public class EditModel : PageModel
    {
        private readonly planApp.Models.MainContext _context;

        public EditModel(planApp.Models.MainContext context)
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

            return RedirectToPage("./Edit");
        }
    }
}
