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
    public class DetailsModel : PageModel
    {
        private readonly AspNetCore7.Data.SchoolContext _context;

        public DetailsModel(AspNetCore7.Data.SchoolContext context)
        {
            _context = context;
        }

      public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            Course = await _context.Courses
                                  .AsNoTracking()
                                  .Include(c => c.Department)
                                  .Include(s => s.Instructors)
                                  .FirstOrDefaultAsync(m => m.CourseID == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
