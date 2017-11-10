using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using planApp.Models; using planApp.Data;

namespace planApp.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;

        public IndexModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Subject> Subject { get;set; }

        public async Task OnGetAsync()
        {
            Subject = await _context.Subject.ToListAsync();
        }
    }
}
