using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudEmpCore.Data;
using CrudEmpCore.Model;

namespace CrudEmpCore.Pages
{
    public class EditModel : PageModel
    {
        private readonly CrudEmpCore.Data.EmpContext _context;

        public EditModel(CrudEmpCore.Data.EmpContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmpRegistration EmpRegistration { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpRegistration = await _context.EmpRegistration.FirstOrDefaultAsync(m => m.EmpId == id);

            if (EmpRegistration == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EmpRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpRegistrationExists(EmpRegistration.EmpId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmpRegistrationExists(int id)
        {
            return _context.EmpRegistration.Any(e => e.EmpId == id);
        }
    }
}
