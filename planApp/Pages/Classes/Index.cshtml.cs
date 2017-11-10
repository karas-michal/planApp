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
    public class IndexModel : PageModel
    {
        private readonly planApp.Data.ApplicationDbContext _context;
        public IList<Class> Class { get; set; }

        public IndexModel(planApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Class = await _context.Class.ToListAsync();
        }
    }
}
