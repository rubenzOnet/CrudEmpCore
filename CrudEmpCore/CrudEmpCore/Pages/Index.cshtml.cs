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
    public class IndexModel : PageModel
    {
        private readonly CrudEmpCore.Data.EmpContext _context;

        public IndexModel(CrudEmpCore.Data.EmpContext context)
        {
            _context = context;
        }

        public IList<EmpRegistration> EmpRegistration { get;set; }

        public async Task OnGetAsync()
        {
            EmpRegistration = await _context.EmpRegistration.ToListAsync();
        }
    }
}
