using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrudEmpCore.Data;
using CrudEmpCore.Model;

namespace CrudEmpCore.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly CrudEmpCore.Data.EmpContext _context;

        public DetailsModel(CrudEmpCore.Data.EmpContext context)
        {
            _context = context;
        }

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
    }
}
