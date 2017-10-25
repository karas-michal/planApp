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
    public class IndexModel : PageModel
    {
        private readonly planApp.Models.TeacherContext _context;

        public IndexModel(planApp.Models.TeacherContext context)
        {
            _context = context;
        }

        public IList<Teacher> Teacher { get;set; }

        public async Task OnGetAsync()
        {
            Teacher = await _context.Teacher.ToListAsync();
        }
    }
}
