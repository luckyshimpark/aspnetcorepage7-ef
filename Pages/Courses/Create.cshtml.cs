using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCore7.Data;
using AspNetCore7.Models;

namespace AspNetCore7.Pages.Courses
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly AspNetCore7.Data.SchoolContext _context;

        public CreateModel(AspNetCore7.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDepartmentsDropDownList(_context);
            //ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentID");            
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCourse = new Course();

            if (await TryUpdateModelAsync<Course>(
                emptyCourse,
                "course",
                c => c.CourseID, 
                c => c.Title, 
                c => c.Credits, 
                c => c.DepartmentID))
            {
                _context.Courses.Add(Course);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateDepartmentsDropDownList(_context, Course.DepartmentID);
            return Page();
        }
    }
}
