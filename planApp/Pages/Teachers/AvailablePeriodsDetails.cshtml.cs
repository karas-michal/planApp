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

        public AvailablePeriod AvailablePeriod { get; set; }
        public int? TeacherID { get; set; }

        public AvailablePeriodsDetailsModel(planApp.Models.MainContext context)
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
    }
}
