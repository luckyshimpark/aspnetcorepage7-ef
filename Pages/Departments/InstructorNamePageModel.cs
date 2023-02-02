using AspNetCore7.Data;
using AspNetCore7.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore7.Pages.Departments;

public class InstructorNamePageModel : PageModel
{
    public SelectList InstructorNameSL { get; set; }

    public void PopulateInstructorsDropDownList(SchoolContext _context,
        object selectedInstructor = null)
    {
        var instructorsQuery = from d in _context.Instructors
                                orderby d.FirstMidName // Sort by name.
                                select d;

        InstructorNameSL = new SelectList(instructorsQuery.AsNoTracking(),
            nameof(Instructor.ID),
            nameof(Instructor.FullName),
            selectedInstructor);
    }
}