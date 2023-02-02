using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCore7.Data;
using AspNetCore7.Models;

namespace AspNetCore7.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<IndexModel> _logger;
        private readonly AspNetCore7.Data.SchoolContext _context;

        public IndexModel(ILogger<IndexModel> logger, 
        AspNetCore7.Data.SchoolContext context,
        IConfiguration configuration)
        {
             _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        public IList<Instructor> Instructor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Instructors != null)
            {
                Instructor = await _context.Instructors
                    .Include(i => i.OfficeAssignment)
                    .Include(c => c.Courses)
                    .AsNoTracking()
                    .ToListAsync();
            }
        }
    }
}
