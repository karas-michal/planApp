using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using planApp.Models;

namespace planApp.Pages.Grades
{
    public class CreateModel : PageModel
    {
        private readonly planApp.Models.MainContext _context;

        public CreateModel(planApp.Models.MainContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Grade Grade { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Grade.Add(Grade);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}