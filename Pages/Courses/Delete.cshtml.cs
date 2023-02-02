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
    public class DeleteModel : PageModel
    {
        private readonly AspNetCore7.Data.SchoolContext _context;

        public DeleteModel(AspNetCore7.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
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
                        .FirstOrDefaultAsync(m => m.CourseID == id);

            if (Course == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Courses.FindAsync(id);

            if (Course != null)
            {                
                _context.Courses.Remove(Course);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
