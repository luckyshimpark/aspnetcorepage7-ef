using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCore7.Data;
using AspNetCore7.Models;

namespace AspNetCore7.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly AspNetCore7.Data.SchoolContext _context;

        public DetailsModel(ILogger<DetailsModel> logger, AspNetCore7.Data.SchoolContext context)
        {
             _logger = logger;
            _context = context;
        }

      public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            //Include 및 ThenInclude 메서드로 인해 컨텍스트가 Enrollment.Course 탐색 속성 및 각 등록 내에서 Student.Enrollments 탐색 속성을 로드합니다.
            //AsNoTracking 메서드는 반환된 엔터티가 현재 컨텍스트에서 업데이트되지 않는 시나리오에서 성능을 향상
            this.Student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (this.Student == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
