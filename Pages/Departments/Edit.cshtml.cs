using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCore7.Data;
using AspNetCore7.Models;

namespace AspNetCore7.Pages.Departments
{
    public class EditModel : InstructorNamePageModel
    {
        private readonly AspNetCore7.Data.SchoolContext _context;

        public EditModel(AspNetCore7.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.Department = await _context.Departments
                .Include(c => c.Administrator)
                .FirstOrDefaultAsync(m => m.DepartmentID == id);

            if (this.Department == null)
            {
                return NotFound();
            }

            PopulateInstructorsDropDownList(_context, Department.DepartmentID);
            
            //Course = course;
           // ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {

            if(id == null)
            {
                return NotFound();
            }

            var departmentToUpdate = await _context.Departments.FindAsync(id);

            if(departmentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Department>(
                departmentToUpdate,
                "department",
                c => c.Name, 
                c => c.Budget, 
                c => c.StartDate,
                c => c.InstructorID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateInstructorsDropDownList(_context, departmentToUpdate.DepartmentID);
            return Page();
        }

        private bool DepartmentExists(int id)
        {
          return _context.Departments.Any(e => e.DepartmentID == id);
        }
    }
}
