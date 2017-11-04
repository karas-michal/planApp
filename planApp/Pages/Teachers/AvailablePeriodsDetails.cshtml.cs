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
    public class AvailablePeriodsDetailsModel : PageModel
    {
        private readonly planApp.Models.MainContext _context;

        public AvailablePeriodsDetailsModel(planApp.Models.MainContext context)
        {
            _context = context;
        }

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
    }
}
