using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Pages.Grades
{
    public class Create1Model : PageModel
    {
        private readonly planApp.Models.MainContext _context;
        [BindProperty]
        public int? StudentID { get; set; }
        [BindProperty]
        public int? SubjectID { get; set; }
        public IList<Subject> Subject { get; set; }

        public Create1Model(planApp.Models.MainContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentID = id;
            Subject = await _context.Subject.ToListAsync();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./GradesCreate2", new { id = StudentID, subjectId = SubjectID });
        }
    }
}