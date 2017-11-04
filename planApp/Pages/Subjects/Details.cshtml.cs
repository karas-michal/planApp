using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Pages.Subjects
{
    public class DetailsModel : PageModel
    {
        private readonly planApp.Models.MainContext _context;

        public DetailsModel(planApp.Models.MainContext context)
        {
            _context = context;
        }

        public Subject Subject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Subject = await _context.Subject.SingleOrDefaultAsync(m => m.ID == id);

            if (Subject == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
