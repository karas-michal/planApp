using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Pages.Classes
{
    public class DetailsModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;
        public Class Class { get; set; }
		public IList<Subject> Subject { get; set; }

		public DetailsModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
			Subject = await _context.Subject.ToListAsync();
			Class = await _context.Class.Include("Students").Include("Requirements").SingleOrDefaultAsync(m => m.ID == id);

            if (Class == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
