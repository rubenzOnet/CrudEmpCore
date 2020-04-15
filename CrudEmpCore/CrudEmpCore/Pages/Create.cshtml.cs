using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrudEmpCore.Data;
using CrudEmpCore.Model;

namespace CrudEmpCore.Pages
{
    public class CreateModel : PageModel
    {
        private readonly CrudEmpCore.Data.EmpContext _context;

        public CreateModel(CrudEmpCore.Data.EmpContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EmpRegistration EmpRegistration { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EmpRegistration.Add(EmpRegistration);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
