using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCore7.Data;
using AspNetCore7.Models;

namespace AspNetCore7.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly AspNetCore7.Data.SchoolContext _context;

        public IndexModel(AspNetCore7.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                Courses = await _context.Courses                
                    .Include(c => c.Department)
                    .Include(s => s.Instructors)
                    .AsNoTracking()
                    .ToListAsync();
            }
        }
    }
}
