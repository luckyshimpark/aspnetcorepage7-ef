using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCore7.Data;
using AspNetCore7.Models;

namespace AspNetCore7.Pages.Departments
{
    public class CreateModel : InstructorNamePageModel
    {
        private readonly AspNetCore7.Data.SchoolContext _context;

        public CreateModel(AspNetCore7.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateInstructorsDropDownList(_context);
            //ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FirstMidName");
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyDepartment = new Department();

            if (await TryUpdateModelAsync<Department>(
                emptyDepartment,
                "department",
                c => c.Name, 
                c => c.Budget, 
                c => c.StartDate, 
                c => c.InstructorID))
            {
                _context.Departments.Add(Department);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }    

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateInstructorsDropDownList(_context, Department.DepartmentID);
            return Page();        
        }
    }
}
