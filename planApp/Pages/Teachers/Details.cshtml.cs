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
    public class DetailsModel : PageModel
    {
        private readonly planApp.Models.MainContext _context;

        public DetailsModel(planApp.Models.MainContext context)
        {
            _context = context;
        }

        public Teacher Teacher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teacher = await _context.Teacher.Include("Availability").Include("Subjects").SingleOrDefaultAsync(m => m.ID == id);


            if (Teacher == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
