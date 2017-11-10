using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using planApp.Models;

namespace planApp.Pages.Classrooms
{
    public class IndexModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;

        public IndexModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Classroom> Classroom { get;set; }

        public async Task OnGetAsync()
        {
            Classroom = await _context.Classroom.ToListAsync();
        }
    }
}
