using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCore7.Data;
using AspNetCore7.Models;
using AspNetCore7.ViewModels;

namespace AspNetCore7.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly AspNetCore7.Data.SchoolContext _context;

        public CreateModel(ILogger<CreateModel> logger, AspNetCore7.Data.SchoolContext context)
        {
             _logger = logger;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        
        //public Student Student { get; set; }
        [BindProperty]
        public StudentVM StudentVM { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Student());
            entry.CurrentValues.SetValues(StudentVM);

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            /*
            var emptyStudent = new Student();

            //나열된 속성만 업데이트합니다
            if(await TryUpdateModelAsync<Student>(
                emptyStudent,
                "student",
                s => s.FirstMidName,
                s => s.LastName,
                s => s.EnrollmentDate
            )){
                _context.Student.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }           
            
            return Page();
            */
        }
    }
}
