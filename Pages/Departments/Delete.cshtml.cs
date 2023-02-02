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
    public class DeleteModel : PageModel
    {
        private readonly AspNetCore7.Data.SchoolContext _context;

        public DeleteModel(AspNetCore7.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
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

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = $"Delete {id} failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
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

            try
            {
                _context.Departments.Remove(Department);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }                

                        
        }
    }
}
