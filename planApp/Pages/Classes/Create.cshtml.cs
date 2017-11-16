using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using planApp.Models; using planApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace planApp.Pages.Classes
{
	[Authorize(Roles = "Admin")]
	public class CreateModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;
        [BindProperty]
        public Class Class { get; set; }

        public CreateModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Class.Add(Class);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}