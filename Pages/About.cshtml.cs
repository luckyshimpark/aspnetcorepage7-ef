

using AspNetCore7.Data;
using AspNetCore7.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore7.Pages;

public class AboutModel : PageModel
{
    private readonly ILogger<AboutModel> _logger;
    private readonly SchoolContext _context;

    public AboutModel(ILogger<AboutModel> logger, SchoolContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IList<EnrollmentDateGroup> Students { get; set; }

    public async Task OnGetAsync()
    {

        /*
        SELECT "s"."EnrollmentDate", COUNT(*) AS "StudentCount"
        FROM "Student" AS "s"
        GROUP BY "s"."EnrollmentDate"
        */
        IQueryable<EnrollmentDateGroup> data =
            from student in _context.Students
            group student by student.EnrollmentDate into dateGroup
            select new EnrollmentDateGroup()
            {
                EnrollmentDate = dateGroup.Key,
                StudentCount = dateGroup.Count()
            };

        Students = await data.AsNoTracking().ToListAsync();
    }
}