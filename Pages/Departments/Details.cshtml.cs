using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCore7.Data;
using AspNetCore7.Models;

namespace AspNetCore7.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly AspNetCore7.Data.SchoolContext _context;

        public DetailsModel(AspNetCore7.Data.SchoolContext context)
        {
            _context = context;
        }

      public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.Department = await _context.Departments
                .AsNoTracking()
                .Include(c => c.Administrator)                
                .FirstOrDefaultAsync(m => m.DepartmentID == id);


            if (this.Department == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
